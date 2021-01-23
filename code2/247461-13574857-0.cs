        private static Byte[] GetBytes(String SomeString)
        {
            Char[] SomeChars = SomeString.ToCharArray();
            Int32 Size = SomeChars.Length * 2;
            List<Byte> TempList = new List<Byte>(Size);
            foreach (Char Character in SomeChars)
            {
                TempList.AddRange(BitConverter.GetBytes(Character));
            }
            return TempList.ToArray();
        }
        private static String GetString(Byte[] ByteArray)
        {
            Int32 Size = ByteArray.Length / 2;
            List<Char> TempList = new List<Char>(Size);
            for (Int32 i = 0; i < ByteArray.Length; i += 2)
            {
                TempList.Add(BitConverter.ToChar(ByteArray, i));
            }
            return new String(TempList.ToArray());
        }
