    [Serializable]
    public class RootObject
    {
        public List<Feature> features { get; set; }
        public int processed_time { get; set; }
        public string type { get; set; }
    }
    
    [Serializable]
        public class AirTemperature
            {
                public string units { get; set; }
                public string value { get; set; }
            }
        
        [Serializable]
            public class Atmo
            {
                public AirTemperature air_temperature { get; set; }
                public DewpointTemperature dewpoint_temperature { get; set; }
                public ObservationTime observation_time { get; set; }
                public RelativeHumidity relative_humidity { get; set; }
                public Visibility visibility { get; set; }
                public WindDirection wind_direction { get; set; }
                public WindGust wind_gust { get; set; }
                public WindSpeed wind_speed { get; set; }
                public PrecipType precip_type { get; set; }
                public Pressure pressure { get; set; }
            }
        
            [Serializable]
            public class Feature
            {
                public Geometry geometry { get; set; }
                public string id { get; set; }
                public Properties properties { get; set; }
                public string type { get; set; }
            }
