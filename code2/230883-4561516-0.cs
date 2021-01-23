    public string WrapUserName 
        {
            get
            {
                return User.UserName          
            }
            set
            {
                User.UserName = value;
                OnPropertyChanged("WrapUserName");
            }
        }
