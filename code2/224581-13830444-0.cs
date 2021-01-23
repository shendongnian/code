    byte[] GetBytesBlock(double[] values)
    {
       var result = new byte[values.Length * sizeof(double)];
       Buffer.BlockCopy(values, 0, result, 0, result.Length);
       return result;
    }
        
    double[] GetDoublesBlock(byte[] bytes)
    {
       var result = new double[bytes.Length / sizeof(double)];
       Buffer.BlockCopy(bytes, 0, result, 0, bytes.Length);
       return result;
    }
