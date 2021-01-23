    public abstract class BaseClass
    {
        public abstract string MyProperty { get; set; }
    }
    
    
    public class DerivedClass : BaseClass
    {
        public override string MyProperty
        {
            get { return "myValue"; }
            set { /* do nothing, not applicable for this class */ }
        } 
    }
