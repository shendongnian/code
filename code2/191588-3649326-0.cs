    public class BaseClass
    {
        public void DoWork() { }
        public int WorkField;
        public int WorkProperty
        {
            get { return 0; }
        }
    }
    
    public class DerivedClass : BaseClass
    {
        public new void DoWork() { }
        public new int WorkField;
        public new int WorkProperty
        {
            get { return 0; }
        }
    }    
    
    DerivedClass B = new DerivedClass();
    B.WorkProperty;  // Calls the new property.
    
    BaseClass A = (BaseClass)B;
    A.WorkProperty;  // Calls the old property.
