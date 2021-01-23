    public class RowComparer : IComparer<Row>
        {
        private List<string> myOrder = new List<string>(new string[] { "FIDUCIAL", "1111", "2222", "DDDD", "4444" });
        private int primaryOrder(Row x)
            {
            int index = myOrder.FindIndex(v => x.Column6.Contains(v));
            return (index >= 0) ? index : myOrder.Count;
            }
        public int Compare(Row x, Row y)
            {
            int result = primaryOrder(x).CompareTo(primaryOrder(y));
            if (result != 0)
                return result;
            return x.Column2.CompareTo(y.Column2);
            }
        }
