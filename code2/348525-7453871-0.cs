        public static Dictionary<string, string> SampleDataList(int startIndex, int pageSize)
        {
            Dictionary<string, string> sampleTable = new Dictionary<string, string>();
            var query = from p in TemporaryData()
                        .Take(pageSize)
                        .Skip(startIndex)
                        select new
                        {
                            FirstColumn = p.Key,
                            SecondColumn = p.Value
                        };
            foreach (var row in query)
            {
                sampleTable.Add(row.FirstColumn, row.SecondColumn);
            }
            return sampleTable;
        }
