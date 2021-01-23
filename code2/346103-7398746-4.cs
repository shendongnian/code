        public string byteToString(byte[] byteArr)
        {
            int i;
            char[] charArr = new char[byteArr.Length*2];
            for (i = 0; i < byteArr.Length; i++)
            {
                charArr[2 * i] = (char)((int)byteArr[i] / 36+48);
                int byt = byteArr[i] % 36; // 36=num of availible charachters
                if (byt < 10)
                {
                    charArr[2*i+1] = (char)(byt + 48); //if % result is a digit
                }
                else
                {
                    charArr[2*i+1] = (char)(byt + 87); //if % result is a letter
                }
            }
            return new String(charArr);
        }
