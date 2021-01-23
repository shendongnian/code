    class Program
    {
        public class Row
        {
            public string Column1 { get; set; }
            public string Column2 { get; set; }
            public string Column3 { get; set; }
            public string Column4 { get; set; }
            public string Column5 { get; set; }
            public string Column6 { get; set; }
        }
        static void Main(string[] args)
        {
            var grid = new []
                           {
                               new Row { Column1 = "J6", Column2 = "RES-0112G", Column3 = "123.123", Column4 = "456.456", Column5 = "180", Column6 = "1111"},
                               new Row { Column1 = "FID2", Column2 = "FIDUCIAL", Column3 = "5.123", Column4 = "-50.005", Column5 = "90", Column6 = "FIDUCIAL"},
                               new Row { Column1 = "R100", Column2 = "RES-0113G", Column3 = "1.1", Column4 = "-123.123", Column5 = "90", Column6 = "1111"},
                               new Row { Column1 = "C12", Column2 = "CAP-1234H", Column3 = "-99.99", Column4 = "-987.123", Column5 = "45", Column6 = "2222"},
                               new Row { Column1 = "Q1", Column2 = "CAP-1234Z", Column3 = "-99.99", Column4 = "-987.123", Column5 = "45", Column6 = "4444"},
                               new Row { Column1 = "J3", Column2 = "RES-0112G", Column3 = "123.123", Column4 = "999.999", Column5 = "0", Column6 = "1111"},
                               new Row { Column1 = "FID1", Column2 = "FIDUCIAL", Column3 = "23.123", Column4 = "23.123", Column5 = "0", Column6 = "FIDUCIAL"},
                               new Row { Column1 = "F1", Column2 = "CAP-1234", Column3 = "-88.99", Column4 = "-555.111", Column5 = "45", Column6 = "DDDD"},
                               new Row { Column1 = "C11", Column2 = "CAP-1234C", Column3 = "-123.99", Column4 = "-123.123", Column5 = "270", Column6 = "abc2222"}
                           };
            var result = grid.
                GroupBy(r => GetSortValue(r.Column6)).
                OrderBy(g => g.Key, new Column6Comparer()).
                SelectMany(g => g.OrderBy(r => r, new RowComparer()));
            foreach (var row in result)
            {
                Console.WriteLine("{0,-6}{1,-13}{2,-10}{3,-12}{4,-6}{5,-10}", row.Column1, row.Column2, row.Column3, row.Column4, row.Column5, row.Column6);
            }
        }
        private static string GetSortValue(string source)
        {
            Match match = new Regex(@"[\d]+").Match(source);
            return match.Success ? match.Value : source;
        }
        private class Column6Comparer : IComparer<string>
        {
            private Dictionary<string, int> ValueToOrder { get; set; } 
            public Column6Comparer()
            {
                ValueToOrder = new Dictionary<string, int>();
                ValueToOrder["FIDUCIAL"] = 0;
                ValueToOrder["1111"] = 1;
                ValueToOrder["2222"] = 2;
                ValueToOrder["DDDD"] = 3;
                ValueToOrder["4444"] = 4;
            }
            public int Compare(string x, string y)
            {
                return ValueToOrder[GetSortValue(x)].CompareTo(ValueToOrder[GetSortValue(y)]);
            }
        }
        private class RowComparer : IComparer<Row>
        {
            public int Compare(Row x, Row y)
            {
                if (x.Column2 == "FIDUCIAL" && y.Column2 == "FIDUCIAL")
                {
                    return x.Column1.CompareTo(y.Column1);
                }
                if (x.Column2 == "FIDUCIAL" || y.Column2 == "FIDUCIAL")
                {
                    return x.Column2 == "FIDUCIAL" ? 0 : 1;
                }
                return x.Column2.Substring(4).CompareTo(y.Column2.Substring(4));
            }
        }
    }
