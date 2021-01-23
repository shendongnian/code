     public static byte[] ReplaceBytes(byte[] src, string replace, string replacewith)
            {
                string hex = BitConverter.ToString(src);
                hex = hex.Replace("-", "");
    
                hex = hex.Replace(replace, replacewith);
                int NumberChars = hex.Length;
                byte[] bytes = new byte[NumberChars / 2];
                for (int i = 0; i < NumberChars; i += 2)
                    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                return src;
            }
