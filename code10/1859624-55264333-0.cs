    public string PrimaryUserName
    {
        get
        {
            return primaryUserNameValue;
        }
        set
        {
            if(primaryUserNameValue != value)
            {
                primaryUserNameValue = value;
                OnPropertyChanged("PrimaryUserName");
            }
        }
    }
