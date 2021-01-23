    class Derived : Base
    {
     public override void Foo() { Console.WriteLine("Derived"); }
     public Base getBase()
     {
      return base; //compiler invalid
     }
    }
