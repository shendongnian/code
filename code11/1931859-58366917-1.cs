    class Caption
    {
        public string AR { get; set; }
        public string EN { get; set; }
        public string Tu { get; set; }
        // This behaves as you want but rather pointless...
        public static implicit operator string(Caption caption) => caption.EN;
        // var cap = new Caption()[language];
        public string this[string language]
        {
            get
            {
                var witch = AR;
                switch(language)
                {
                    case nameof(EN):
                        witch = EN;
                        break;
                    case nameof(Tu):
                        witch = Tu;
                        break;
                }
                return witch;
            }
        }
    }
