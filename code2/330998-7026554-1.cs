    class A
    {
       public delegate void MyDelegate(object sender, int x);
       public event MyDelegate TheEvent;
       public void func()
       {
         if(TheEvent != null) TheEvent(this, 123);
       }
    }
    class B
    {
       public B()
       {
         A a = new A();
         a.TheEvent += handler;
         a.func();
       }
       public void handler(object sender, int x)
       {
          // "sender" is a reference to object of type A that we've created in ctor
          // "x" is 123
          // "this" is a reference to B (b below)
       } 
    }
    B b = new B(); // here it starts
