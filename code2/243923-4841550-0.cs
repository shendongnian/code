    private int Red
    {
        get { return (int)color.R; }
        set { 
            if (value < 0 || value > 255) throw new ArgumentOutOfRangeException();
            color.R = (byte)value;
        }
    }
