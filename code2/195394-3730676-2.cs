    /// <summary>
    /// Taken from https://stackoverflow.com/questions/9033/hidden-features-of-c/407325#407325
    /// instead of doing (enum & value) == value you can now use enum.Has(value)
    /// </summary>
    /// <typeparam name="T">Type of enum</typeparam>
    /// <param name="type">The enum value you want to test</param>
    /// <param name="value">Flag Enum Value you're looking for</param>
    /// <returns>True if the type has value bit set</returns>
    public static bool Has<T>(this System.Enum type, T value)
    {
       return (((int)(object)type & (int)(object)value) == (int)(object)value);
    } 
