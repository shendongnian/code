    time.Minutes = 510;
    // in class def:
    public int Minutes
    {
        get { return minutes; }
        set
        {
            hours = value / 60;
            minutes = value % 60;
        }
    }
