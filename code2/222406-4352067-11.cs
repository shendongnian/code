    public static class StringHelper
    {
        // It should be noted that this method is expecting UTF-8 input only,
        // so you probably should give it a more fitting name.
        public static byte[] ToUTF8ByteArray(this string str)
        {
            Encoding encoding = new UTF8Encoding();
            return encoding.GetBytes(str);
        }
    }
