    private string role;
    [Required]
    public string Role
    {
        get => role;
        private set
        {
            role = value;
            RaisePropertyChanged("Role");
        }
    }
    public bool EndUser
    {
        get => Role == "EndUser";
        set
        {
            Role = "EndUser";
            RaisePropertyChanged("EndUser");
            RaisePropertyChanged("AppDeveloper");
        }
    }
    public bool AppDeveloper
    {
        get => Role == "AppDeveloper";
        set
        {
            Role = "AppDeveloper";
            RaisePropertyChanged("AppDeveloper");
            RaisePropertyChanged("EndUser");
        }
    }
