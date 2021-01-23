    [Flags]
    public enum SwitchStatus : int // or long
    {
        xMin = 1,
        xMax = 1<<1,
        yMin = 1<<2,
        yMax = 1<<3,
        ...
    }
    
    SwitchStatus status = (SwitchStatus)Convert.ToInt32(value, 2);
