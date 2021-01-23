    public bool IsInRange(string value)
    {
       bool isInRange = false;
       
       double parsed = 0;
       if (Double.TryParse(value, out parsed))
       {
          // use >= and <= if you want the range to be from -90.0 to 90.0 inclusive
          isInRange = value > -90.0 && value < 90.0;
       }
       return isInRange;
    }
