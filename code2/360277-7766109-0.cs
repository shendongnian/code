    [ValueRange(Max = 10, Min = 5)]
    public int X
    {
        set
        {
           this.ValidateRangeValue(this.X, value);
        }
    }
