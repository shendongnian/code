    [AttributeUsage(AttributeTargets.Method)]
    public class MyAttributeAttribute : Attribute
    {
        private readonly string name;
        public MyAttributeAttribute(string name)
        {
            this.name = name;
        }
    }
    public class Test
    {
        public int Value
        {
            [MyAttribute("Get")]get;
            [MyAttribute("Set")]set;
        }
    }
