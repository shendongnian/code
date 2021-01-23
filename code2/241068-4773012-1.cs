    using System;
    
    public class Base
    {
        public Base()
        {
            Dump();
        }
        
        public virtual void Dump() {}    
    }
    
    class Child : Base
    {
        private string x = "initialized in declaration";
        private string y;
        
        public Child()
        {
            y = "initialized in constructor";
        }
        
        public override void Dump()
        {
            Console.WriteLine("x={0}; y={1}", x, y);
        }
    }
    
    class Test
    {
        static void Main(string[] args)
        {
            new Child();
        }
    }
