    /// <summary>
    /// Find the maximum absolute value in an array
    /// </summary>
    /// <param name="array">The array</param>
    public static double MaxAbs(this double[,] array)
    {
        var packed = array.ToPackedArray();
        return packed[MaxAbsIndex(packed)];
    }
    /// <summary>
    /// Find the minimum absolute value in an array
    /// </summary>
    /// <param name="array">The array</param>
    /// <param name="exclude_zero">Ignore zero values?</param>
    public static double MinAbs(this double[,] array, bool exclude_zero = true)
    {
        var packed = array.ToPackedArray();
        return packed[MinAbsIndex(packed, exclude_zero)];
    }
    /// <summary>
    /// Find the index of the maximum absolute value in an array
    /// </summary>
    /// <param name="array">The array</param>
    public static int MaxAbsIndex(this double[] array)
    {
        int res = 0;
        double x = array[0];
        for (int i = 1; i<array.Length; i++)
        {
            var t = Abs(array[i]);
            if (t>x)
            {
                x=t;
                res = i;
            }
        }
        return res;
    }
    /// <summary>
    /// Find the index of the minimum absolute value in an array
    /// </summary>
    /// <param name="array">The array</param>
    /// <param name="exclude_zero">Ignore zero values?</param>
    public static int MinAbsIndex(this double[] array, bool exclude_zero = true)
    {
        int offset = 0;
        // skip leading zeros if exclude_zero is enabled.
        while (exclude_zero && offset<array.Length && Abs(array[offset])==0)
        {
            offset++;
        }
        int res = offset;
        double x = Abs(array[offset]);
        for (int i = offset+1; i < array.Length; i++)
        {
            var t = Abs(array[i]);
            if (t<x && (t>0 || !exclude_zero))
            {
                x = t;
                res = i;
            }
        }
        return res;
    }
