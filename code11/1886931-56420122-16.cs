       public bool IsEndUser
        {
            get => Role == "EndUser";
            set
            {
                if(value)
                  Role = "EndUser";
                NotifyPropertyChanged("IsEndUser");
            }
        }
    
        public bool IsAppDeveloper
        {
            get => Role == "AppDeveloper";
            set
            {
                if(value)
                   Role = "AppDeveloper";
                NotifyPropertyChanged("IsAppDeveloper");
            }
