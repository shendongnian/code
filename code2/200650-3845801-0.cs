    abstract class ClassA
    {
        public abstract string MyProperty
        {
            get;
        }
    }
    
    class ClassB : ClassA
    {
        public override string MyProperty
        {
            get { return "prop_b"; }
        }
    }
    
    class ClassC : ClassA
    {
        public override string MyProperty
        {
            get { return "prop_c"; }
        }
    }
    
    var instB = new ClassB();
    var instC = new ClassC();
    var b = instB.MyProperty;
    var c = instC.MyProperty;
