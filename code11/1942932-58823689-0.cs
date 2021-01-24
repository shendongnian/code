public void Convert(WeatherObject weatherObject)
{
	IEnumerable<YahooWeatherModel> models = from forecast in weatherObject.forecasts
		select new YahooWeatherModel
		{
			Country = weatherObject.location.country,
			City = weatherObject.location.city,
			Code = forecast.Code,
			Date = System.Convert.ToDateTime(forecast.Date),
			Day = forecast.Day,
			High = System.Convert.ToInt32(forecast.High),
			Low = System.Convert.ToInt32(forecast.Low),
			Text = forecast.Text
		};
}
