    public class ShortNameAttribute : RegularExpressionAttribute
    {
        public ShortNameAttribute() : base(@"[a-z] {4,} ")
        {
        }
    }
    public class InvalidCharsAttribute : RegularExpressionAttribute
    {
        public InvalidCharsAttribute() : base(@"[a-z]")
        {
        }
    }
    [ShortNameAttribute]
    [InvalidCharsAttribute] 
    public string Name { get; set; }
