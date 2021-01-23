        public static string[] SplitCsv(string line)
        {
            List<string> result = new List<string>();
            StringBuilder currentStr = new StringBuilder("");
            bool inQuotes = false;
            for (int i = 0; i < line.Length; i++) // For each character
            {
                if (inQuotes) // Are we in between quotes ?
                {
                    if (line[i] == '\"') // Quotes are closing
                        inQuotes = false;
                    else
                        currentStr.Append(line[i]); // Add character to current string
                }
                else // We are not in between quotes
                {
                    if (line[i] == '\"') // Quotes are opening
                        inQuotes = true;
                    else if (line[i] == ',') // Comma : end of the current string, add it to result
                    {
                        result.Add(currentStr.ToString());
                        currentStr.Clear();
                    }
                    else
                        currentStr.Append(line[i]); // Add character to current string
                }
            }
            result.Add(currentStr.ToString());
            return result.ToArray(); // Return array of all strings
        }
