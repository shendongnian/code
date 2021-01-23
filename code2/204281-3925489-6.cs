    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    using log4net;
    
    namespace MyCompany.Cipher
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    
        public string GenerateSha1HashForString(string valueToHash, EncodeStyle encodeStyle)
        {
            string hashedString = string.Empty;
    
            try
            {
                hashedString = SHA1HashEncode(Encoding.UTF8.GetBytes(valueToHash), encodeStyle);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error(string.Format("{0}\r\n{1}", ex.Message, ex.StackTrace)); }
                throw new Exception("Error trying to hash a string; information can be found in the error log", ex);
            }
    
            return hashedString;
        }
    
        private string ByteArrayToString(byte[] bytes, EncodeStyle encodeStyle)
        {
            StringBuilder output = new StringBuilder(bytes.Length);
    
            if (EncodeStyle.Base64 == encodeStyle)
            {
                return Convert.ToBase64String(bytes);
            }
    
            for (int i = 0; i < bytes.Length; i++)
            {
                switch (encodeStyle)
                {
                    case EncodeStyle.Dig:
                        //encode to decimal with 3 digits so 7 will be 007 (as range of 8 bit is 127 to -128)
                        output.Append(bytes[i].ToString("D3"));
                        break;
                    case EncodeStyle.Hex:
                        output.Append(bytes[i].ToString("X2"));
                        break;
                }
            }
    
            return output.ToString();
        }
    
        private string SHA1HashEncode(byte[] valueToHash, EncodeStyle encode)
        {
            SHA1 a = new SHA1CryptoServiceProvider();
            byte[] arr = new byte[60];
            string hash = string.Empty;
    
            arr = a.ComputeHash(valueToHash);
            hash = ByteArrayToString(arr, encode);
    
            return hash;
        }
    }
