       public bool IsEndUser
        {
            get => Role == "EndUser";
            set
            {
                Role = "EndUser";
                NotifyPropertyChanged("IsEndUser");
            }
        }
    
        public bool IsAppDeveloper
        {
            get => Role == "AppDeveloper";
            set
            {
                Role = "AppDeveloper";
                NotifyPropertyChanged("IsAppDeveloper");
            }
