    public class ConditionalOptions
    {
        [Key]
        public Int64 ConditionalOptionsId { get; set; }
        
        public string show { get; set; }
        public string when { get; set; }
        public string eq { get; set; }
        public virtual ComponentOptions ComponentOptions { get; set; }
    }
