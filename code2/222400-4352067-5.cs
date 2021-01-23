    public static class StringHelper
    {
        // It should be noted that this method is expecting UTF-8 input only,
        // so you probably should give it a more fitting name.
        public static byte[] ToByteArray(this string str)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetBytes(str);
        }
    }
