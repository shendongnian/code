    public bool IsInRange(string value)
    {
       bool isInRange = false;
       
       double parsed = 0;
       if (Double.TryParse(value, out parsed))
       {
          isInRange = value > -90.0 && value < 90.0;
       }
       return isInRange;
    }
