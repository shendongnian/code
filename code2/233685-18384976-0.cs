    public class BytesProvider<T>
    {
        public static Func<T, byte[]> Convert;
        static BytesProvider()
        {
            BytesProvider<bool>.Convert = x => BitConverter.GetBytes(x);
            BytesProvider<byte>.Convert = x => new byte[]{x};
            BytesProvider<Int32>.Convert = x => BitConverter.GetBytes(x);
            BytesProvider<UInt16>.Convert = x => BitConverter.GetBytes(x);
            // additional conversions here
        }
    }
