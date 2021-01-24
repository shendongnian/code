    Monkey selectedMonkey;
    public Monkey SelectedMonkey
    {
        get
        {
            return selectedMonkey;
        }
        set
        {
            if (selectedMonkey != value)
            {
                selectedMonkey.MyTextColor = "Red"; //Here is changing the color
                selectedMonkey = value;
            }
        }
    }
