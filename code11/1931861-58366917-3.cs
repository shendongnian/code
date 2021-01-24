    class Caption
    {
        public string AR { get; set; }
        public string EN { get; set; }
        public string Tu { get; set; }
        // var cap = new Caption()[language];
        public string this[string language]
        {
            get
            {
                var which = AR;
                switch(language)
                {
                    case nameof(EN):
                        which = EN;
                        break;
                    case nameof(Tu):
                        which = Tu;
                        break;
                }
                return which;
            }
        }
    }
