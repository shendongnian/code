       private delegate int MyDelegate(string a);
       private int Foo(string a)
       {
       }
       MethodInfo mFoo = this.GetType().GetMethod("Foo");
       var @delegate = Delegate.CreateDelegate(typeof (MyDelegate), mFoo, false);
       if(@delegate!= null)
       {
          // compatible
        }
        else
        {
           // not compatible
        }
