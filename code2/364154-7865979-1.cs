    public string Artist
    {
        get { return artists[0]; }
    }
    public string[] Artists
    {
        // get { return artists; }   // get string[] is optional
        set { artists = value; OnPropertyChanged("Artist"); OnPropertyChanged("Artists");}
    }
