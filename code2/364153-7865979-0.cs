    public string Artist
    {
        get { return artists[0]; }
    }
    public string[] Artists
    {
        get { return artists; } 
        set { artists = value; OnPropertyChanged("Artist"); OnPropertyChanged("Artists");}
    }
