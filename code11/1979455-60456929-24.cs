    public class Base64Manager
    {
        public static byte[] Base64ToByteArray(String base64)
        {
            return Convert.FromBase64String(base64);
        }
    
        public static String ToBase64(byte[] data, Boolean insertLineBreaks = default(Boolean))
        {
            return insertLineBreaks ? Convert.ToBase64String(data, Base64FormattingOptions.InsertLineBreaks) : Convert.ToBase64String(data);
        }
    }
