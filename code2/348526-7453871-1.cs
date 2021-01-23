        public static Dictionary<string, string> SampleDataList(int startIndex, int pageSize)
        {
            var sampleTable = new Dictionary<string, string>();
            var page = TemporaryData().Skip(startIndex).Take(pageSize);
            var query = from p in page
                        select new
                        {
                            FirstColumn = p.Key,
                            SecondColumn = p.Value
                        };
            foreach (var row in query)
                sampleTable.Add(row.FirstColumn, row.SecondColumn);
            return sampleTable;
        }
