    public class Row
        {
            public string Column1 { get; set; }
            public string Column2 { get; set; }
            public string Column3 { get; set; }
            public string Column4 { get; set; }
            public string Column5 { get; set; }
            public string Column6 { get; set; }
        }
    
    public interface IComplexSorter<T> : IComparer<T>
        {
        }
    
    public class ComplexSorter<T> : IComplexSorter<T>
        {
            private IList<IComplexSorter<T>> _rowSorters;
    
            public ComplexSorter()
            {
                _rowSorters = new ReadOnlyCollectionBuilder<IComplexSorter<T>>();
            }
    
            public int Compare(T x, T y)
            {
                foreach (var sorter in Sorters)
                {
                    int value = sorter.Compare(x, y);
                    if (value != 0)
                        return value;
                }
                return 0;
            }
    
            public IList<IComplexSorter<T>> Sorters
            {
                get { return _rowSorters; }
            }
        }
    
    public class RowColumn1Sorter : IComplexSorter<Row>
        {
            public int Compare(Row x, Row y)
            {
                if (x.Column6 == "FIDUCIAL" && y.Column6 == "FIDUCIAL")
                    return x.Column1.CompareTo(y.Column1);
    
                if (x.Column6 == "FIDUCIAL" || y.Column6 == "FIDUCIAL")
                    return x.Column6 == "FIDUCIAL" ? 0 : 1;
    
                return 0;
            }
        }
    
    public class RowColumn2Sorter : IComplexSorter<Row>
        {
            public int Compare(Row x, Row y)
            {
                return x.Column2.Substring(4).CompareTo(y.Column2.Substring(4));
            }
        }
    
    public class RowColumn6Sorter : IComplexSorter<Row>
        {
            private static IList<string> SortOrder;
    
            public RowColumn6Sorter()
            {
                SortOrder = new string[] { "FIDUCIAL", "1111", "2222", "DDDD", "4444" }.ToList();
            }
    
            public int Compare(Row x, Row y)
            {
                string xSortValue = SortOrder.Contains(x.Column6) ? x.Column6 : ExtractNumeric(x.Column6);
                string ySortValue = SortOrder.Contains(y.Column6) ? y.Column6 : ExtractNumeric(y.Column6);
                int xKey = SortOrder.IndexOf(xSortValue);
                int yKey = SortOrder.IndexOf(ySortValue);
                xKey = xKey == -1 ? SortOrder.Count:xKey;
                yKey = yKey == -1 ? SortOrder.Count:yKey;
                return xKey - yKey;
            }
    
            private string ExtractNumeric(String value)
            {
                Match match = new Regex(@"[\d]+").Match(value);
                return match.Success ? match.Value : value;
            }
        }
    
    class Program
        {
            static void Main(string[] args)
            {
                var data = new[]
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
                }.ToList();
    
                ComplexSorter<Row> rowSorter = new ComplexSorter<Row>();
                rowSorter.Sorters.Add(new RowColumn6Sorter());
                rowSorter.Sorters.Add(new RowColumn1Sorter());
                rowSorter.Sorters.Add(new RowColumn2Sorter());
    
                data.Sort(rowSorter);
    
                foreach (var row in data)
                {
                    Console.WriteLine("{0,-6}{1,-13}{2,-10}{3,-12}{4,-6}{5,-10}", row.Column1, row.Column2, row.Column3, row.Column4, row.Column5, row.Column6);
                }
                Console.ReadKey();
            }
        }
