	public enum FoolEnum
        {
            AAA, BBB, CCC, DDD
        };
        FoolEnum _Fool;
        public FoolEnum Fool
        {
            get { return _Fool; }
            set { ValidateRaiseAndSetIfChanged(ref _Fool, value); }
        }
