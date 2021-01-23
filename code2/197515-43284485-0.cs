        public static string[] SplitRow(string record, string delimiter, string qualifier, bool trimData)
        {
            // In-Line for example, but I implemented as string extender in production code
            Func <string, int, int> IndexOfNextNonWhiteSpaceChar = delegate (string source, int startIndex)
            {
                if (startIndex >= 0)
                {
                    if (source != null)
                    {
                        for (int i = startIndex; i < source.Length; i++)
                        {
                            if (!char.IsWhiteSpace(source[i]))
                            {
                                return i;
                            }
                        }
                    }
                }
                return -1;
            };
            var results = new List<string>();
            var result = new StringBuilder();
            var inQualifier = false;
            var inField = false;
            // We add new columns at the delimiter, so append one for the parser.
            var row = $"{record}{delimiter}";
            for (var idx = 0; idx < row.Length; idx++)
            {
                // A delimiter character...
                if (row[idx]== delimiter[0])
                {
                    // Are we inside qualifier? If not, we've hit the end of a column value.
                    if (!inQualifier)
                    {
                        results.Add(trimData ? result.ToString().Trim() : result.ToString());
                        result.Clear();
                        inField = false;
                    }
                    else
                    {
                        result.Append(row[idx]);
                    }
                }
                // NOT a delimiter character...
                else
                {
                    // ...Not a space character
                    if (row[idx] != ' ')
                    {
                        // A qualifier character...
                        if (row[idx] == qualifier[0])
                        {
                            // Qualifier is closing qualifier...
                            if (inQualifier && row[IndexOfNextNonWhiteSpaceChar(row, idx + 1)] == delimiter[0])
                            {
                                inQualifier = false;
                                continue;
                            }
                            else
                            {
                                // ...Qualifier is opening qualifier
                                if (!inQualifier)
                                {
                                    inQualifier = true;
                                }
                                // ...It's a qualifier inside a qualifier.
                                else
                                {
                                    inField = true;
                                    result.Append(row[idx]);
                                }
                            }
                        }
                        // Not a qualifier character...
                        else
                        {
                            result.Append(row[idx]);
                            inField = true;
                        }
                    }
                    // ...A space character
                    else
                    {
                        if (inQualifier || inField)
                        {
                            result.Append(row[idx]);
                        }
                    }
                }
            }
            return results.ToArray<string>();
        }
