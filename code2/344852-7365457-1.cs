    public class FilterBase<T> {
        protected int startRow;
        ...
    
        public FilterBase(Func<T, IComparable> sortBy, bool sortAscending, int startRow, int numRow) {
            //assigns to member variables
        }
        public IEnumerable<T> Filter(IEnumerable<T> toFilter) {
            filtered = DoFiltering(toFilter);
            filtered = DoPaging(filtered);
            filtered = DoSorting();
            return filtered;
        }
        protected abstract IEnumerable<T> DoFiltering(IEnumerable<T> toFilter);
        protected virtual IEnumerable<T> DoPaging(IEnumerable<T> toFilter) {
            return toFilter.Skip(startRow).Take(numRow);
        }
        protected virtual IEnumerable<T> DoSorting(IEnumerable<T> toFilter) {
            return sortAscending ? toFilter.OrderBy(sortBy) : toFilter.OrderByDescending(sortBy);
        }
    }
    
    public class BookFilter : FilterBase<Book> {
        public BookFilter(string id, string year, string sortBy, string sorDir, int startRow, int numRow) : base(sortBy, sorDir, startRow, numRow) {
            //assign id and year to member variables
        }
        protected override IEnumerable<Book> DoFiltering(IEnumerable<Book> toFilter) {
            return toFilter.Where(b => b.Id == id && b.Year == year);
        }
    }
