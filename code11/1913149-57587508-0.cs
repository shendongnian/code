    private bool easy;
    public bool Easy
    {
        get { return easy; }
        set
        {
            easy = value;
            if (value == true)
            {
                Medium = false;
                Hard = false;
            }
            OnPropertyChanged();
        }
    }
    
    private bool medium;
    public bool Medium
    {
        get { return medium; }
        set
        {
            medium = value;
            if (value == true)
            {
                Easy = false;
                Hard = false;
            }
            OnPropertyChanged();
        }
    }
    
    private bool hard;
    public bool Hard
    {
        get { return hard; }
        set
        {
            hard = value;
            if (value == true)
            {
                Medium = false;
                Easy = false;
            }
            OnPropertyChanged();
        }
    }
