    public static string CustomReplace(string srcText, string toFind, string toReplace, bool matchCase, bool replaceOnce)
        {
            StringComparison sc = StringComparison.OrdinalIgnoreCase;
            if (matchCase)
                sc = StringComparison.Ordinal;
            int pos;
            int previousProcessedLength = 0;
            string alreadyProcessedTxt = "";
            string remainingToProcessTxt = srcText;
            while ((pos = remainingToProcessTxt.IndexOf(toFind, sc)) > -1)
            {
                previousProcessedLength = alreadyProcessedTxt.Length;
                //Append processed text up until the end of the found string and perform replacement
                alreadyProcessedTxt += remainingToProcessTxt.Substring(0, pos + toFind.Length);
                alreadyProcessedTxt = alreadyProcessedTxt.Remove(previousProcessedLength + pos, toFind.Length);
                alreadyProcessedTxt = alreadyProcessedTxt.Insert(previousProcessedLength + pos, toReplace);
                //Remove processed text from remaining
                remainingToProcessTxt = remainingToProcessTxt.Substring(pos + toFind.Length);                
                if (replaceOnce)
                    break;
            }
            return alreadyProcessedTxt + remainingToProcessTxt;
        }
