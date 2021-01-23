    interface IFilter {
        public Expression<Func<ILogEntry, bool>> GetPredicate();
    }
    ...
    IQueryable<ILogEntry> entries = ...
    foreach(var filter in filters) {
        entries = entries.Where(filter.GetPredicate());
    }
