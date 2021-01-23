    public class DateTimeComparer : IComparer<DateTime?>
    {
        #region IComparer<DateTime?> Members
    
        public int Compare(DateTime? x, DateTime? y)
        {
            DateTime nx = x ?? DateTime.MaxValue;
            DateTime ny = y ?? DateTime.MaxValue;
    
            return nx.CompareTo(ny);
        }
    
        #endregion
    }
