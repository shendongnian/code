    public abstract class Filter {
        
    }
    public class OrFilter : Filter {
        public string Clause1 {get; set;}
        public string Clause2 {get; set;}
    }
    public class ItemMustExistFilter : Filter {
         public string ItemName {get; set;}
    }
    public class Report {
        // For the sake of the example, I know that public setters on Lists are not
        // best practice
        public IList<Filter> Filters {get;set;}
    }
