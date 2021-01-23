    public class A {
    
      public B b;
    
      public A(B newB) { b = newB; }
    
      private static A _empty = new A(B.Empty);
      public static A Empty { get { return _empty; }}
    
    }
    
    public class B {
    
      public C c;
    
      public B(C newC) { c = newC; }
    
      private static B _empty = new B(C.Empty);
      public static B Empty { get { return _empty; } }
    
    }
    
    public class C {
    
      public E e;
    
      public C(E newE) { e = newE; }
    
      private static C _empty = new C(E.Empty);
      public static C Empty { get { return _empty; } }
    
    }
    
    public class E {
    
      public string name;
    
      public E(string newName) { name = newName; }
    
      private static E _empty = new E(null);
      public static E Empty { get { return _empty; } }
    
    }
