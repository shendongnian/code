        string originalSSN = Convert.ToString("123-456-789").PadLeft(9, '0');
            int maskDigit = 6;
            string maskSSN = originalSSN.Substring(originalSSN.Length - maskDigit, maskDigit);            
            if (Regex.IsMatch(maskSSN, "(—)|(–)|(-)"))
            {
                int i = maskDigit;
                while (Regex.Replace(maskSSN, "(—)|(–)|(-)", "").Length < maskDigit)
                {
                    i++;
                    maskSSN = originalSSN.Substring(originalSSN.Length - i, i);
                }
                string[] ssnArray = Regex.Split(maskSSN, "(—)|(–)|(-)", RegexOptions.ExplicitCapture);
                if (ssnArray.Length > 1)
                {
                    maskSSN = originalSSN.Substring(originalSSN.Length - maskDigit - (ssnArray.Length - 1), maskDigit + (ssnArray.Length - 1));
                }
                
            }
            maskSSN = maskSSN.PadLeft(9, '#');
