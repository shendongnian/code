    public class BitConverter<T>
    {
        public static Func<T, byte[]> GetBytes;
        static BitConverter()
        {
            BitConverter<byte>.GetBytes = x => new byte[] { x };
            BitConverter<bool>.GetBytes = x => BitConverter.GetBytes(x);
            BitConverter<char>.GetBytes = x => BitConverter.GetBytes(x);
            BitConverter<double>.GetBytes = x => BitConverter.GetBytes(x);
            BitConverter<Int16>.GetBytes = x => BitConverter.GetBytes(x);
            BitConverter<Int32>.GetBytes = x => BitConverter.GetBytes(x);
            BitConverter<Int64>.GetBytes = x => BitConverter.GetBytes(x);
            BitConverter<Single>.GetBytes = x => BitConverter.GetBytes(x);
            BitConverter<UInt16>.GetBytes = x => BitConverter.GetBytes(x);
            BitConverter<UInt32>.GetBytes = x => BitConverter.GetBytes(x);
            BitConverter<UInt64>.GetBytes = x => BitConverter.GetBytes(x);
        }
    }
