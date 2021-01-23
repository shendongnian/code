    public bool IsValid { }
    [ValueRange(Max = 10, Min = 5)]
    public int X
    {
        set
        {
           this.ValidateValueRange(this.X, value);
        }
    }
    private bool ValidateValueRange(...)
    {
       // 1. Get property value (see link below regarding retrieving a property)
       // 2. Get ValueRange attribute values
       // 3. Update this.IsValid
       // 4. Return ...
    }
