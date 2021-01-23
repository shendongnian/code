     class Base
    {
        public virtual void Foo() { Console.WriteLine("Base"); }
    }
    class Derived : Base
    {
        // Change virtual with new
        // public override void Foo() { Console.WriteLine("Derived"); }
        public new void Foo() { Console.WriteLine("Derived"); }
    }
    
    static void Main(string[] args)
        {
            Derived d = new Derived();
            d.Foo();// Output: Derived
            typeof(Base).GetMethod("Foo").Invoke(d, null);// Output: Base
            
            // Or you can cast
            ((Base)d).Foo();// Output: base
            
            Console.ReadLine();
        }
