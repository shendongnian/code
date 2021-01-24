    public enum SortField
    {
        All,
        A,
        B,
        C
    }
    public class SortingRepresentation
    {
        public SortField Field { get; set; }
        public string DisplayLabel { get; set; }
        public Type ClientType { get; set; }        
    }
