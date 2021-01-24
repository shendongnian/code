	[XmlInclude(typeof(MyEnum)), XmlInclude(typeof(SomeOtherClass)) /* Include all other expected custom types here*/]
    public class ValueContainer
    {
        public object Value;
    }
