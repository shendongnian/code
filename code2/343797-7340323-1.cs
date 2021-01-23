    using System;
    
    public abstract class BaseClass : ICloneable
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
    
    public class Derived : BaseClass
    {
        private readonly string name;
        
        public Derived(string name)
        {
            this.name = name;
        }
        
        public override string ToString()
        {
            return "Derived with name " + name;
        }
    }
    
    class Test
    {
        static void Main(string[] args)
        {
            BaseClass b = new Derived("fred");
            
            object clone = b.Clone();
            Console.WriteLine(clone.ToString());
        }
    }
