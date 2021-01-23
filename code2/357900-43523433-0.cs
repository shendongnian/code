    public delegate string FormatterFunc(string val);
    public enum Formatter
    {
        None,
        PhoneNumberFormatter
    }
    
    public static readonly FormatterFunc[] FormatterMappings = { null, PhoneNumberFormatter };
    
