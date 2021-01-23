    public class DateTimeComparer : IComparer<DateTime?>
        {
            #region IComparer<DateTime?> Members
    
            public int Compare(DateTime? x, DateTime? y)
            {
                DateTime nx = x.HasValue ? x.Value : DateTime.MaxValue;
                DateTime ny = y.HasValue ? y.Value : DateTime.MaxValue;
    
                return nx.CompareTo(ny);
            }
    
            #endregion
        }
