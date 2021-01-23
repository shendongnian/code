        public EnumsAvailable ListOfEnumValues
        {
            get { return new EnumsAvailable(); }
        }
        public EnumsAvailable ChosenEnum { 
            get { return _ChosenEnum; }
            set
            {
                if (_ChosenEnum != value)
                {
                    _ChosenEnum = value;
                    RaisePropertyChanged(() => ChosenEnum);
                }
            } 
        }
