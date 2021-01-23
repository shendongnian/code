    abstract class ClassA
    {
        public abstract string MyProperty
        {
            get;
        }
        public void DoIt()
        {
            Console.WriteLine(this.MyProperty);
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
    instB.DoIt();
    instC.DoIt();
