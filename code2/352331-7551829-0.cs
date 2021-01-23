    public class A {
      public string name;
      public int f() { return 42; }
    }
    
    public class B {
      private A a;
      public int f() { return a.f(); }
      public string getName() { return a.name; }
    }
