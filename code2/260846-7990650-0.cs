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
