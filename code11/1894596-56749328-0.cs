        public static string UrlEncode(string value)
        {
          // code stripped
            return Encoding.UTF8.GetString(UrlEncode(bytes, 0, bytes.Length, false /* alwaysCreateNewReturnValue */));
        }
        //private one makes a call to IntToHex
        private static byte[] UrlEncode(byte[] bytes, int offset, int count)
        {
          expandedBytes[pos++] = (byte)IntToHex((b >> 4) & 0xf);
        // IntToHex casting to uppercase character, reason being every 
        // encoded character is returning as uppercase.
        private static char IntToHex(int n)
        {
           //code stripped
            else
                return (char)(n - 10 + (int)'A');  //here
        }
