    public class DateStringComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return DateTime.Compare(DateTime.Parse(x.ToString()), DateTime.Parse(y.ToString()));
        }
    }
