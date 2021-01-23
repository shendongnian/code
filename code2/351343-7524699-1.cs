    public class LogComparer : IComparer<Log>
    {
        public int Compare(Log x, Log y)
        {
            if ( x == y ) return 0;
            if ( x.LoggedType == y.LoggedType ) return 0;
            if ( x.LoggedType == LogType.Fatal ) return 1;
            if ( y.LoggedType == LogType.Fatal ) return -1;
            // etc.
        }
    }
    // Usage similar to this
    logs.OrderBy(x => x, new LogComparer());
