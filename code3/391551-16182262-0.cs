    abstract class DataSource : ILoopingSelectorDataSource
    {
        private DateTimeWrapper _selectedItem;
        public object GetNext(object relativeTo)
        {
            DateTime? next = GetRelativeTo(((DateTimeWrapper)relativeTo).DateTime, 1);
            return null;// next.HasValue ? new DateTimeWrapper(next.Value) : null;
        }
        public object GetPrevious(object relativeTo)
        {
            DateTime? next = GetRelativeTo(((DateTimeWrapper)relativeTo).DateTime, -1);
            return next.HasValue ? new DateTimeWrapper(next.Value) : null;
        }
