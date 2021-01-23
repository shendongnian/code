    class Foo
    {
     public string Bar(int value) { return value.ToString(); }
    }
    
    void Main()
    {
     object foo = new Foo();
     
     // We have an instance of something and want to call a method with this signature on it :
     // public string Bar(int value);
     
     {
      // Cast and Direct method call
      var result = ((Foo)foo).Bar(42);
      result.Dump();
     }
     {
      // Using MethodInfo.Invoke
      var method = foo.GetType().GetMethod("Bar");
      var result = (string)method.Invoke(foo, new object[] { 42 });
      result.Dump();
     }
     {
         // Using the dynamic keyword
      var dynamicFoo = (dynamic)foo;
      var result = (string)dynamicFoo.Bar(42);
      result.Dump();
     }
     {
         // Using CreateDelegate
      var method = foo.GetType().GetMethod("Bar");
      var func = (Func<int, string>)Delegate.CreateDelegate(typeof(Func<int, string>), foo, method);
      var result = func(42);
      result.Dump();
     }
     {
         // Create an expression and compile it to call the delegate on one instance.
      var method = foo.GetType().GetMethod("Bar");
      var thisParam = Expression.Constant(foo);
      var valueParam = Expression.Parameter(typeof(int), "value");
      var call = Expression.Call(thisParam, method, valueParam);
      var lambda = Expression.Lambda<Func<int, string>>(call, valueParam);
      var func = lambda.Compile();
      var result = func(42);
      result.Dump();
     }
    }
