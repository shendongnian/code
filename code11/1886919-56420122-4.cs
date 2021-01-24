       public bool IsEndUser
        {
            get => Role == "EndUser";
            set
            {
                Role = "EndUser";
                NotifyPropertyChanged("EndUser");
                NotifyPropertyChanged("AppDeveloper");
            }
        }
    
        public bool IsAppDeveloper
        {
            get => Role == "AppDeveloper";
            set
            {
                Role = "AppDeveloper";
                NotifyPropertyChanged("EndUser");
                NotifyPropertyChanged("AppDeveloper");
            }
