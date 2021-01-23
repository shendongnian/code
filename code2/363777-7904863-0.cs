     /// <summary>
            /// Parses each string passed as a "row".
            /// This routine accounts for both double quotes
            /// as well as commas currently, but can be added to
            /// </summary>
            /// <param name="row"> string or row to be parsed</param>
            /// <returns></returns>
            private List<String> ParseRowToList(String row)
            {
                List<String> returnValue = new List<String>();
                
                if (row[0] == '\"')
                {// Quoted String
                    if (row.IndexOf("\",") > -1)
                    {// There are more columns
                        returnValue = ParseRowToList(row.Substring(row.IndexOf("\",") + 2));
                        returnValue.Insert(0, row.Substring(1, row.IndexOf("\",") - 1));
                    }
                    else
                    {// This is the last column
                        returnValue.Add(row.Substring(1, row.Length - 2));
                    }
                }
                else
                {// Unquoted String
                    if (row.IndexOf(",") > -1)
                    {// There are more columns
                        returnValue = ParseRowToList(row.Substring(row.IndexOf(",") + 1));
                        returnValue.Insert(0, row.Substring(0, row.IndexOf(",")));
                    }
                    else
                    {// This is the last column
                        returnValue.Add(row.Substring(0, row.Length));
                    }
                }
    
                return returnValue;
    
            }
