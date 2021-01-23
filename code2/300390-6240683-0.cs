    public class BaseClass
    {
        [Serialized]
        public string MyProperty { get; set; }
    }
    
    public class ChildClass : BaseClass
    {
        public bool ShouldSerializeMyProperty { get { return false; } }
    }
