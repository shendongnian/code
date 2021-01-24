    public static class EncodingExtensions
    {
        public static string GetString(this Encoding encoding, Span<byte> source)
        {
            return encoding.GetString(source.ToArray());
        }
    }
