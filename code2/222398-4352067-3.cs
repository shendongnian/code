    public static class StringHelper
    {
        public static byte[] ToByteArray(this string str)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetBytes(str);
        }
    }
