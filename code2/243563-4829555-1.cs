        public enum DataUsage
        {
            Count,
            Average,
            Median,
            Percentage
        }
        public class DataAnnotationAttribute : Attribute
        {
            public DataAnnotationAttribute(DataUsage usage)
            {
                this.Usage = usage;
            }
            public DataUsage Usage { get; private set; }
        }
        [DataAnnotation(DataUsage.Average)]
        public decimal MyProperty { get; set; }        
