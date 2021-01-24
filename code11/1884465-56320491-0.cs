         public static string ConvertStringToHex(String input, System.Text.Encoding encoding)
        {
             Byte[] stringBytes = encoding.GetBytes(input);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
             {
                 sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }
