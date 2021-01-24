    public enum MyEnum
    {
        Default, //The default value to apply in the event of an invalid Enum value
        [XmlEnumAttribute("10")]
        Item10,
        [XmlEnumAttribute("20")]
        Item20
    }
    public class MyClass
    {
        public string Value { get; set; }
        public MyEnum EnumValue
        {
            get
            {
                foreach (var field in typeof(MyEnum).GetFields()) 
                {
                    if (field.GetCustomAttribute<XmlEnumAttribute>()?.Name == Value)
                    {
                        return (MyEnum)field.GetValue(null);
                    }
                }
                return default;
            }
        }
    }
