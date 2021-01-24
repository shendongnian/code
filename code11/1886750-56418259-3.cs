        [NotMapped]
        public PriceSeries DailyValues { get; set; }
        [Column("DailyValues")]
        public string DailyValuesSerialized
        {
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
        [NotMapped]
        public PriceSeries IntraDayValues { get; set; }
        [Column("IntraDayValues")]
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
