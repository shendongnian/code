    class A 
    {
       protected int x = 123;
    }
    
    class B : A 
    {
       void F() 
       {
          A a = new A();  
          B b = new B();  
          a.x = 10;   // Error
          b.x = 10;   // OK
       }
    }
