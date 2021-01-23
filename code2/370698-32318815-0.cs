    /// <summary>
    /// Get the integral and floating point portions of a Double
    /// as separate integer values, where the floating point value is 
    /// raised to the specified power of ten, given by 'places'.
    /// </summary>
    public static void Split(Double value, Int32 places, out Int32 left, out Int32 right)
    {
        left = (Int32)Math.Truncate(value);
        right = (Int32)((value - left) * Math.Pow(10, places));
    }
    public static void Split(Double value, out Int32 left, out Int32 right)
    {
        Split(value, 1, out left, out right);
    }
    
