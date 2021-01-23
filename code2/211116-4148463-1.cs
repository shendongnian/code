      public SomeCommand SomeCommand
      {
            get { return _someCommand; }
                set
                {
                    _someCommand = value;
                    OnPropertyChanged("SomeCommand");
                }
            }
