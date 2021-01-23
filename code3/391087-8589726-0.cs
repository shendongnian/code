    public class MyClassLight
    {
        public int PropertyInt { get; set; } // 4 byte value type
        public OtherClass1 PropertyOtherClass1 { get; set; } // 4 or 8 byte reference type
    }
    public class MyClassHeavy
    {
        public int PropertyInt { get; set; } // 4 byte value type
        public string PropertyString { get; set; } // 4 or 8 byte reference type
        public OtherClass1 PropertyOtherClass1 { get; set; } // 4 or 8 byte reference type
        public OtherClass2 PropertyOtherClass2 { get; set; } // 4 or 8 byte reference type
    }
