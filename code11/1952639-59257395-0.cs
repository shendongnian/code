        [HttpGet("{networkID:int}/{ConstituentID:int}")]
        public IEnumerable<WeatherForecast> Get([FromRoute]int networkID,
            [FromRoute]int ConstituentID, [FromQuery]string values)
        {
            // received string is: "GDWarn:4.1,GDLimit:3.7,NDWarn:6.3,NDLimit:4.8"
            var dict = new Dictionary<string, double>();
            foreach (var item in values.Split(','))
                dict.Add(item.Split(':')[0], Convert.ToDouble(item.Split(':')[1]));
            return (...)
        }
