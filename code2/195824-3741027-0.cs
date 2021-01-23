    /// <summary>
    /// Searches the current array for a specified subarray and returns the index
    /// of the first occurrence, or -1 if not found.
    /// </summary>
    /// <param name="sourceArray">Array in which to search for the
    /// subarray.</param>
    /// <param name="findWhat">Subarray to search for.</param>
    /// <param name="startIndex">Index in <paramref name="sourceArray"/> at which
    /// to start searching.</param>
    /// <param name="sourceLength">Maximum length of the source array to search.
    /// The greatest index that can be returned is this minus the length of
    /// <paramref name="findWhat"/>.</param>
    public static int IndexOfSubarray<T>(this T[] sourceArray, T[] findWhat,
            int startIndex, int sourceLength) where T : IEquatable<T>
    {
        if (sourceArray == null)
            throw new ArgumentNullException("sourceArray");
        if (findWhat == null)
            throw new ArgumentNullException("findWhat");
        if (startIndex < 0 || startIndex > sourceArray.Length)
            throw new ArgumentOutOfRangeException();
        var maxIndex = sourceLength - findWhat.Length;
        for (int i = startIndex; i <= maxIndex; i++)
        {
            if (sourceArray.SubarrayEquals(i, findWhat, 0, findWhat.Length))
                return i;
        }
        return -1;
    }
    /// <summary>Determines whether the two arrays contain the same content in the
    /// specified location.</summary>
    public static bool SubarrayEquals<T>(this T[] sourceArray,
            int sourceStartIndex, T[] otherArray, int otherStartIndex, int length)
            where T : IEquatable<T>
    {
        if (sourceArray == null)
            throw new ArgumentNullException("sourceArray");
        if (otherArray == null)
            throw new ArgumentNullException("otherArray");
        if (sourceStartIndex < 0 || length < 0 || otherStartIndex < 0 ||
            sourceStartIndex + length > sourceArray.Length ||
            otherStartIndex + length > otherArray.Length)
            throw new ArgumentOutOfRangeException();
        for (int i = 0; i < length; i++)
        {
            if (!sourceArray[sourceStartIndex + i]
                .Equals(otherArray[otherStartIndex + i]))
                return false;
        }
        return true;
    }
