    public static string base64Decode(string data)
    {
         byte[] toDecodeByte = Convert.FromBase64String(data);
        
         System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
         System.Text.Decoder utf8Decode = encoder.GetDecoder();
        
         int charCount = utf8Decode.GetCharCount(toDecodeByte, 0, toDecodeByte.Length);
        
         char[] decodedChar = new char[charCount];
         utf8Decode.GetChars(toDecodeByte, 0, toDecodeByte.Length, decodedChar, 0);
         string result = new String(decodedChar);
         return result;
    }
    
