            string inputUnicodeString = "你好";
            SqlString mySqlString = new SqlString(inputUnicodeString);
            byte[] mbcsBytes = mySqlString.GetNonUnicodeBytes();
            string outputMbcsString = string.Empty;
            for (int index = 0; index < mbcsBytes.Length; index++)
            {
                outputMbcsString += Convert.ToChar(mbcsBytes[index]);
            }
