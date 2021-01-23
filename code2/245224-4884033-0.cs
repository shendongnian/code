    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public sealed class ReversStringMatchAttribute : ValidationAttribute
    {
        public string Property { get; set; }        
        public ReversStringMatchAttribute()
        { }
        public override bool IsValid(object value)
        {
            return true;
        }
    }
