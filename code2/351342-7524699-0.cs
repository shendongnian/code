    public class LogTypeComparer : IComparer<LogType>
    {
        public int Compare(LogTye x, LogType y)
        {
            if ( x == y ) return 0;
            if ( x == LogType.Fatal ) return 1;
            if ( y == LogType.Fatal ) return -1;
            // etc.
        }
    }
    // Usage similar to this
    logs.OrderBy(x => x, new LogTypeComparer());
