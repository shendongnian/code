    Public Shared ReadOnly Property TodaysWeather As WeatherReporter
        Get
            Return New WeatherReporter(DateTime.Now)
        End Get
    End Property
      
