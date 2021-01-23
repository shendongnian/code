    public static bool TryConvertToInt32(decimal val, out int intval)
    {
        if (val > int.MaxValue || val < int.MinValue)
        {
          intval = 0; // assignment required for out parameter
          return false;
        }
        
        intval = Decimal.ToInt32(val);
        
        return true;
    }
