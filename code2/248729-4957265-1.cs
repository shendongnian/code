            set
            {
                if (lastname != value)
                {
                   _lastName = value;
                   RaisePropertyChanged("LastName");
                   RaisePropertyChanged("FullName");
                }
            }
