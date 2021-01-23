    class BaseClass
    {
         public void Foo() { Console.WriteLine("Foo"); }
    }
    class Derived : BaseClass
    {
         public new void Foo() { Console.WriteLine("Bar"); }
    }
    public static void Main()
    {
         Derived derived = new Derived();
         derived.Foo(); // Prints "Bar"
         BaseClass baseClass = derived;
         baseClass.Foo(); // Prints "Foo"
    }
