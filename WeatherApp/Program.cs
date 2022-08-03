using Newtonsoft.Json.Linq;

Console.WriteLine("Give me a zip code to see current temperature");
int zipCode = int.Parse(Console.ReadLine());

var client = new HttpClient();

var apiResponse = File.ReadAllText("appsettings.json");

var apiKey = JObject.Parse(apiResponse).GetValue("weatherKey");

string weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode},US&appid={apiKey}&units=imperial";

var weatherJsonResponse = client.GetStringAsync(weatherURL).Result;

var weatherObject = JObject.Parse(weatherJsonResponse);

double currentTemp = double.Parse(weatherObject["main"]["temp"].ToString());

string yourCity = weatherObject.GetValue("name").ToString();

Console.WriteLine($"The current temperature in {yourCity} is {currentTemp} degrees fahrenheit");
