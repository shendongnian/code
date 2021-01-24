        public static byte[] StringToBytes2(string str)
        {
            string[] parts = str.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
            byte[] bytes = new byte[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] != "")
                {
                    string temp = String.Format("0{0}", parts[i]);
                    bytes[i] = Convert.ToByte(temp, 16);
                }
            }
            return bytes;
        }
