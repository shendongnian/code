        [JsonIgnore]
        public PriceSeries DailyValues { get; set; }
        [JsonProperty(PropertyName = "DailyValues")]
        public string DailyValuesSerialized {
            get
            {
                return (DailyValues == null) ?
                    null : 
                    DailyValues.Serialize(TimeSeriesSerializationType.ValuesOnly);
            }
            set
            {
                DailyValues = (value == null) ? null : new PriceSeries(value);
            }
        }
        [JsonIgnore]
        public PriceSeries IntraDayValues { get; set; }
        [JsonProperty(PropertyName = "IntraDayValues")]
        public string IntraDayValuesSerialized
        {
            get
            {
                return (IntraDayValues == null) ?
                    null : 
                    IntraDayValues.Serialize(TimeSeriesSerializationType.Normal);
            }
            set
            {
                IntraDayValues = (value == null) ? null : new PriceSeries(value);
            }
        }
