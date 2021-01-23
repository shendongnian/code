    static string ReplaceOccurrence(string input, string wordToReplace, string replaceWith, int occToReplace)
            {
                MatchCollection matches = Regex.Matches(input, string.Format("([\\w]*)", wordToReplace), RegexOptions.IgnoreCase);
                int occurrencesFound = 0;
                int captureIndex = 0;
    
                foreach (Match matchItem in matches)
                {
                    if (matchItem.Value == wordToReplace)
                    {
                        occurrencesFound++;
                        if (occurrencesFound == occToReplace)
                        {
                            captureIndex = matchItem.Index;
                            break;
                        }
                    }
                }
                if (captureIndex > 0)
                {
                    return string.Format("{0}{1}{2}", input.Substring(0, captureIndex), replaceWith, input.Substring(captureIndex + wordToReplace.Length));
                } else 
                {
                    return input;
                }
            }
