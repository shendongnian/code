     private string ConvertNumber(string englishNumber)
        {
            string theResult = "";
            foreach (char ch in englishNumber)
            {
                theResult += (char)(1776 + char.GetNumericValue(ch));
            }
            return theResult;
        }
