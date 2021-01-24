            public string ParseData(string input)
            {
                StringBuilder numberBuilder = new StringBuilder();
                string terminatorChars = "am";
                bool isCaseSensitive = false;
    
                int terminatorCharLength = terminatorChars.Length;
    
                for (int i = 0; i < input.Length; i++)
                {
                    if (input.Length - i >= terminatorCharLength)
                    {
                        var currentSubstr = input.Substring(i, terminatorCharLength);
                        if ((currentSubstr == terminatorChars) || (!isCaseSensitive && currentSubstr.ToLowerInvariant() == terminatorChars.ToLowerInvariant()))
                            if(numberBuilder.Length>0)
                                return numberBuilder.ToString();
                    }
    
                    if (Char.IsDigit(input[i]) || input[i] == '.')
                        numberBuilder.Append(input[i]);
                    else if (Char.IsWhiteSpace(input[i]))
                        continue;
                    else
                        numberBuilder.Clear();
                }
    
                return null;
            }
