        public string byteToString(byte[] byteArr)
        {
            int i;
            char[] charArr = new char[byteArr.Length];
            for (i = 0; i < byteArr.Length; i++)
            {
                int byt = byteArr[i] % 36; // 36=num of availible charachters
                if (byt < 10)
                {
                    charArr[i] = (char)(byt + 48); //if % result is a digit
                }
                else
                {
                    charArr[i] = (char)(byt + 97); //if % result is a letter
                }
            }
            return new String(charArr);
        }
