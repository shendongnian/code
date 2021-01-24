    public class ConditionalOptions
    {
        [Key, ForeignKey("ComponentOptions")]
        public Int64 FormId { get; set; }
        public string show { get; set; }
        public string when { get; set; }
        public string eq { get; set; }
    
        public virtual ComponentOptions ComponentOptions { get; set; }
    }
