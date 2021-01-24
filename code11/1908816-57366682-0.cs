    public static byte[] GetBigEndianBytes(params int[] args)
    {
        var result = new byte[args.Length * sizeof(int)];           
        for (var argIndex = 0; argIndex < args.Length; argIndex++)
        {
            var bytes = BitConverter.GetBytes(args[argIndex]).Reverse().ToArray();
            for (var byteIndex = 0; byteIndex < bytes.Length; byteIndex++)
            {
                result[byteIndex + argIndex * sizeof(int)] = bytes[byteIndex];
            }
        }
        return result;
    }
