    static double[] GetDoubles(byte[] bytes)
    {
        return Enumerable.Range(0, bytes.Length / sizeof(double))
            .Select(offset => BitConverter.ToDouble(bytes, offset * sizeof(double)))
            .ToArray();
    }
    static double[] GetDoublesAlt(byte[] bytes)
    {
        var result = new double[bytes.Length / sizeof(double)];
        Buffer.BlockCopy(bytes, 0, result, 0, bytes.Length);
        return result;
    }
