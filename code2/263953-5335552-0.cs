    public class BaseClass
    {
        private string something;
    
        public BaseClass() : this("default value") // Call the BaseClass(string) ctor
        {
        }
        
        public BaseClass(string something)
        {
            this.something = something;
        }
        // other ctors if needed
    }
    
    public class SubClass : BaseClass
    {
        public SubClass(string something) : base(something) // Call the base ctor with the arg
        {
        }
        // other ctors if needed
    }
