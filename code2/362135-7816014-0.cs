        class DescendedDateComparer : IComparer<DateTime>
        {
            public int Compare(DateTime x, DateTime y)
            {
                // use the default comparer to do the original comparison for datetimes
                int ascendingResult = Comparer<DateTime>.Default.Compare(x, y);
                // turn the result around
                return 0 - accendingResult;
            }
        }
        static void Main(string[] args)
        {
            SortedList<DateTime, string> test = new SortedList<DateTime, string>(new DescendedDateComparer());
        }
