    using System.Numerics;
    /// <summary>Adds each pair of elements in two arrays, and replaces the
    /// left array element with the result.</summary>
    public static void Add_UsingVector(byte[] left, byte[] right, int start, int length)
    {
        int i = start;
        int step = Vector<byte>.Count; // the step is 16
        int end = start + length - step + 1;
        for (; i < end; i += step)
        {
            // Vectorize 16 bytes from each array
            var vector1 = new Vector<byte>(left, i);
            var vector2 = new Vector<byte>(right, i);
            vector1 += vector2; // Vector arithmetic is unchecked only
            vector1.CopyTo(left, i);
        }
        for (; i < start + length; i++) // Process the last few elements
        {
            unchecked { left[i] += right[i]; }
        }
    }
