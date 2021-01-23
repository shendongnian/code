        public class CustomComparer : IComparer<Row>
            {
            Predicate<Row>[] myOrder = new Predicate<Row>[]
            {
                (row) => row.Column6 == "FIDUCIAL",
                (row) => row.Column6.Contains("1111") && !row.Column3.Contains("unwanted"),
                (row) => row.Column6.Contains("2222"),
                (row) => row.Column6.StartsWith("DDDD"),
                (row) => row.Column6 == "4444",
            };
            private int primaryOrder(Row row)
                {
                for (int i = 0; i < myOrder.Length; i++)
                    {
                    if (myOrder[i](row))
                        return i;
                    }
                return myOrder.Length;
                }
            public int Compare(Row x, Row y)
                {
                int result = primaryOrder(x).CompareTo(primaryOrder(y));
                if (result != 0)
                    return result;
                return x.Column2.CompareTo(y.Column2);
                }
            }
