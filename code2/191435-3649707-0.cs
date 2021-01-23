    /// <summary>
    /// Determines if the current value is included in the range of specified values. Bounds are included.
    /// </summary>
    /// <typeparam name="T">The type of the values</typeparam>
    /// <param name="val">The value.</param>
    /// <param name="firstValue">The lower bound.</param>
    /// <param name="secondValue">The upper bound.</param>
    /// <returns>
    /// Return <c>true</c> if the <paramref name="val">value</paramref> is between the <paramref name="firstValue"/> and the <paramref name="secondValue"/>; otherwise, <c>false</c>
    /// </returns>
    public static bool Between<T>(this T val, T firstValue, T secondValue) where T : IComparable<T>
    {
      if (val == null)
        throw new ArgumentNullException();
    
      if (firstValue == null ||
          secondValue == null)
        return false;
        
      return firstValue.CompareTo(val) <= 0 && secondValue.CompareTo(val) >= 0;
    }
