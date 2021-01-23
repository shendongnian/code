    class A {
      public virtual void M1() {
        Console.WriteLine("A.M1()");
      }
    }
    class B : A {
      public new virtual void M1() {
        Console.WriteLine("B.M1()");
      }
    }
  
    class Program {
      static void Main(string[] args) {
        B b = new B();
        A a = b;
        a.M1();
      }
    }
