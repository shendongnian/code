    <h1>Weather forecast</h1>
    <p>This component demonstrates fetching data from the server.</p>
    <p *ngIf="!forecasts"><em>Loading...</em></p>
    <table class='table table-striped' *ngIf="forecasts">
      <thead>
        <tr>
          <th>Date</th>
          <th>Temp. (C)</th>
          <th>Temp. (F)</th>
          <th>Summary</th>
        </tr>
      </thead>
      <tbody>
        <tr *ngFor="let forecast of forecasts">
          <td>{{ forecast.dateFormatted }}</td>
          <td>{{ forecast.temperatureC }}</td>
          <td>{{ forecast.temperatureF }}</td>
          <td>{{ forecast.summary }}</td>
        </tr>
      </tbody>
    </table>
    <button class='btn btn-default pull-left' (click)="OnClick('Prior')">Previous</button>
    <button class='btn btn-default pull-left' (click)="OnClick('Next')">Next</button>
    <button class='btn btn-default pull-right' (click)="OnClick('Post')">Post</button>
    using Microsoft.AspNetCore.Mvc;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	namespace NG_22.Controllers
	{
		[Route("api/[controller]/[action]")] 
		public class SampleDataController : Controller
		{
			private static string[] Summaries = new[]
			{
				"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
			};
			[HttpGet]
			public IEnumerable<WeatherForecast> WeatherForecasts(int startDateIndex = 0)
			{
				var rng = new Random();
				return Enumerable.Range(1, 5).Select(index => new WeatherForecast
				{
					DateFormatted = DateTime.Now.AddDays(index + startDateIndex).ToString("d"),
					TemperatureC = rng.Next(-20, 55),
					Summary = Summaries[rng.Next(Summaries.Length)]
				});
			}
			[HttpPost]
			public object PostWeatherForecast([FromBody] WeatherForecast weatherForecast)
			{
				var forecast = weatherForecast;
				//return weatherForecast;
				return new
				{
					DateFormatted = DateTime.Now.ToString("d"),
					TemperatureC = 30,
					Summary = Summaries[2]
				};
			}
			public class WeatherForecast
			{
				public string DateFormatted { get; set; }
				public int TemperatureC { get; set; }
				public string Summary { get; set; }
				public int TemperatureF
				{
					get
					{
						return 32 + (int)(TemperatureC / 0.5556);
					}
				}
				public object Data { get; set; }
			}
		}
	}
