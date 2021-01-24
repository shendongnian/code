    public class SomeClass
    {
        public SomeOtherClass Class { get; }
    }
    public class SomeOtherClass
    {
        public string Test { get; set; }
    }
    public static class SomeClassExtension
    {
        public static string IsNullOrEmpty(this SomeClass obj)
        {
            if(obj.Class == null || string.IsNullOrEmpty(obj.Class.Test))
                return "(null)";
            return obj.Class.Test;
        }
    }
