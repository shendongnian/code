    public static class CompressionHelper
    {
        public static byte[] GZipHeaderBytes = {0x1f, 0x8b, 8, 0, 0, 0, 0, 0, 4, 0};
        public static byte[] GZipLevel10HeaderBytes = {0x1f, 0x8b, 8, 0, 0, 0, 0, 0, 2, 0};
        public static bool IsPossiblyGZippedBytes(this byte[] a)
        {
            var yes = a.Length &gt;= 10;
            if (!yes)
            {
                return false;
            }
            var header = a.SubArray(0, 10);
            return header.SequenceEqual(GZipHeaderBytes) || header.SequenceEqual(GZipLevel10HeaderBytes);
        }
    }
