    public class FilterBase {
        protected string sortBy;
        ...
    
        public FilterBase(string sortBy, string sorDir, int startRow, int numRow) {
            //assigns to member variables
        }
    }
    
    public class BookFilter : FilterBase {
        public BookFilter(string id, string year, string sortBy, string sorDir, int startRow, int numRow) : base(sortBy, sorDir, startRow, numRow) {
            //assign id and year to member variables
        }
    }
