    public class MaxStringLengthAttribute : Attribute
    {
        public int MaxLength { get; set; }
        public MaxStringLengthAttribute(int length) { this.MaxLength = length; }
    }
