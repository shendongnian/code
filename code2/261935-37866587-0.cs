                   /// <summary>
        /// Microsoft style csv file.  " is the quote character, "" is an escaped quote.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="sepChar"></param>
        /// <param name="quoteChar"></param>
        /// <param name="escChar"></param>
        /// <returns></returns>
        public static List<string[]> ReadCSVFileMSStyle(string fileName, char sepChar = ',', char quoteChar = '"')
        {
            List<string[]> ret = new List<string[]>();
            string[] csvRows = System.IO.File.ReadAllLines(fileName);
            foreach (string csvRow in csvRows)
            {
                bool inQuotes = false;
                List<string> fields = new List<string>();
                string field = "";
                for (int i = 0; i < csvRow.Length; i++)
                {
                    if (inQuotes)
                    {
                        // Is it a "" inside quoted area? (escaped litteral quote)
                        if(i < csvRow.Length - 1 && csvRow[i] == quoteChar && csvRow[i+1] == quoteChar)
                        {
                            i++;
                            field += quoteChar;
                        }
                        else if(csvRow[i] == quoteChar)
                        {
                            inQuotes = false;
                        }
                        else
                        {
                            field += csvRow[i];
                        }
                    }
                    else // Not in quoted region
                    {
                         if (csvRow[i] == quoteChar)
                        {
                            inQuotes = true;
                        }
                        if (csvRow[i] == sepChar)
                        {
                            fields.Add(field);
                            field = "";
                        }
                        else 
                        {
                            field += csvRow[i];
                        }
                    }
                }
                if (!string.IsNullOrEmpty(field))
                {
                    fields.Add(field);
                    field = "";
                }
                ret.Add(fields.ToArray());
            }
            return ret;
        }
    }
