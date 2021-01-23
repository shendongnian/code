            int iChecksum = 0;
            int iDigit = 0;
            for (int i = 0; i < sSIN.Length; i++)
            {
                // even number else odd
                if (((i+1) % 2) == 0)
                {
                    iDigit = int.Parse(sSIN.Substring(i, 1))*2;
                    iChecksum += (iDigit < 10) ? iDigit : iDigit - 9;
                }
                else
                {
                    iChecksum += int.Parse(sSIN.Substring(i, 1));
                }
            }
            return ((iChecksum % 10) == 0) ? true : false;
        }
