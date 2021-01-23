        private string GetNumberFromString(string sLongString, int iLimitNumbers)
        {
            string sReturn = "NA";
            int iNumbersCounter = 0;
            int iCharCounter = 0; 
            string sAlphaChars = string.Empty;
            string sNumbers = string.Empty;
            foreach (char str in sLongString)
            {
                if (char.IsDigit(str))
                {
                    sNumbers += str.ToString();
                    iNumbersCounter++;
                    if (iNumbersCounter == iLimitNumbers)
                    {
                        return sReturn = sNumbers;
                    }
                }
                else
                {
                    sAlphaChars += str.ToString();
                    iCharCounter++;
                    // reset the counter 
                    iNumbersCounter = 0; 
                }
            }
            return sReturn;
        }
