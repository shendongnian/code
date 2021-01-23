    public static class CSV
    {
        public static List<string[]> Import(string file, char csvDelimiter, bool ignoreHeadline, bool removeQuoteSign)
        {
            return ReadCSVFile(file, csvDelimiter, ignoreHeadline, removeQuoteSign);
        }
        private static List<string[]> ReadCSVFile(string filename, char csvDelimiter, bool ignoreHeadline, bool removeQuoteSign)
        {
            string[] result = new string[0];
            List<string[]> lst = new List<string[]>();
            string line;
            int currentLineNumner = 0;
            int columnCount = 0;
            // Read the file and display it line by line.  
            using (System.IO.StreamReader file = new System.IO.StreamReader(filename))
            {
                while ((line = file.ReadLine()) != null)
                {
                    currentLineNumner++;
                    string[] strAr = line.Split(csvDelimiter);
                    // save column count of dirst line
                    if (currentLineNumner == 1)
                    {
                        columnCount = strAr.Count();
                    }
                    else
                    {
                        //Check column count of every other lines
                        if (strAr.Count() != columnCount)
                        {
                            throw new Exception(string.Format("CSV Import Exception: Wrong column count in line {0}", currentLineNumner));
                        }
                    }
                    if (removeQuoteSign) strAr = RemoveQouteSign(strAr);
                    if (ignoreHeadline)
                    {
                        if(currentLineNumner !=1) lst.Add(strAr);
                    }
                    else
                    {
                        lst.Add(strAr);
                    }
                }
            }
            return lst;
        }
        private static string[] RemoveQouteSign(string[] ar)
        {
            for (int i = 0;i< ar.Count() ; i++)
            {
                if (ar[i].StartsWith("\"") || ar[i].StartsWith("'")) ar[i] = ar[i].Substring(1);
                if (ar[i].EndsWith("\"") || ar[i].EndsWith("'")) ar[i] = ar[i].Substring(0,ar[i].Length-1);
            }
            return ar;
        }
    }
