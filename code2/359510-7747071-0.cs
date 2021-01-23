    class A 
    {
       protected int x() {}
    }
    class B : A 
    {
       void F() 
       {
          A a = new A();  
          B b = new B();  
          a.x();   // Error
          b.x();   // OK
       }
    }
