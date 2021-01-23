    public class PageModel
    {
        public Collection<RowItem> RowItems { get; set; }
    }
    
    public class RowItem
    {
        public int Id {get;set;}
        public string MoreFields { get; set; }
    }
