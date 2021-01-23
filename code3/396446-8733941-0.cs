    class A
    {
       public void F() { Console.WriteLine("A.F"); }
       public virtual void G() { Console.WriteLine("A.G"); }
    }
    class B: A
    {
       new public void F() { Console.WriteLine("B.F"); }
       public override void G() { Console.WriteLine("B.G"); }
    }
    class Test
    {
       static void Main() {
          B b = new B();
          A a = b;
          a.F(); //prints A.F
          b.F(); //prints B.F
          a.G(); //prints B.G (due to virtual method override)
          b.G(); //prints B.G
       }
    }
