    public abstract class DemoBase
    {
        private readonly string name;    
        public string Name { get { return name; } }
            
        protected DemoBase(string name)
        {
            this.name = name;
        }
        // Abstract members here, probably
    }
    
    public class FixedNameDemo : DemoBase
    {
        public FixedNameDemo()
            : base ("Always the same name")
        {
        }
        
        // Other stuff here
    }
    
    public class VariableNameDemo : DemoBase
    {
        public VariableNameDemo(string name)
            : base(name)
        {
        }
    
        // Other stuff here
    }
