        public struct OHLC
        {
            private long _UTCdate { get; set; }
            public DateTime UTCdate
            {
                get { return DateTime.FromBinary(_UTCdate); }
                set { _UTCdate = value.ToBinary(); }
            }
            public double open { get; set; }
            public double High { get; set; }
            public double Low { get; set; }
            public double Close { get; set; }
        }
