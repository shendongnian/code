    public static class EncodingExtensions
    {
        public static string GetString(this Encoding encoding, Span<byte> source)
        {
            //naive way using ToArray, but possible to improve when needed
            return encoding.GetString(source.ToArray());
        }
    }
