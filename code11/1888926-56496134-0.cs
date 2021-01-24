        public static string RoundString(string value, int decimalPlaces)
        {
            StringBuilder returnValue = new StringBuilder(value);
            int startIndex = 0;
            int charIndex = 0;
            while (charIndex < value.Length && startIndex == 0)
            {
                if (value[charIndex].ToString() == ".")
                    startIndex = charIndex + 1;
                charIndex++;
            }
            if (int.Parse(value[charIndex + decimalPlaces + 1].ToString()) >= 5)
            {
                bool rounded = false;
                for (charIndex = startIndex + decimalPlaces; charIndex > -1; charIndex--)
                {
                    if (!rounded && charIndex != startIndex-1)
                    { 
                        int newVal = int.Parse(returnValue[charIndex].ToString()) + 1;
                        if (newVal > 9)
                        {
                            returnValue[charIndex] = '0';
                        }
                        else
                        {
                            returnValue[charIndex] = (int.Parse(returnValue[charIndex].ToString()) + 1).ToString()[0];
                            rounded = true;
                        }
                    }
                }
                if (!rounded)
                {
                    startIndex++;
                    returnValue = new StringBuilder("1" + returnValue.ToString());
                }
            }
            return returnValue.ToString().Substring(0, startIndex + decimalPlaces);
        }
