    public delegate string FormatterFunc(string val);
    public enum Formatter
    {
        None,
        PhoneNumberFormatter
    }
    
    public static readonly FormatterFunc[] FormatterMappings = { null, PhoneNumberFormatter };
    
    public string SomeFunction(string zzz)
    {
       //The property in the attribute is named CustomFormatter
       return FormatterMappings[(int)YourAttributeHere.CustomFormatter](zzz);
    }
