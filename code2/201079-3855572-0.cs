    public int Height
    {
        get
        {
           return int.Parse(hd_Height.Value).ToString();
        }
        set
        {
            hd_Height.Value = value.ToString();
        }
    }
