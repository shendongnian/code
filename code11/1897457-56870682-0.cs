    public class ConditionalOptions
    {
        [Key, ForeignKey("ComponentOptions1"), Column(Order = 0)]
        public Int64 FormId { get; set; }
    
        [Key, ForeignKey("ComponentOptions2"), Column(Order = 1)]
        public int Key { get; set; }
        public string show { get; set; }
        public string when { get; set; }
        public string eq { get; set; }
    
        public virtual ComponentOptions ComponentOptions1 { get; set; }
        public virtual ComponentOptions ComponentOptions2 { get; set; }
    }
