    using (IronPython.Hosting.PythonEngine engine = new IronPython.Hosting.PythonEngine())
    {
       engine.Execute(@"
       def foo(a, b):
       return a+b*2");
       
       // (1) Retrieve the function
       IronPython.Runtime.Calls.ICallable foo = (IronPython.Runtime.Calls.ICallable) engine.Evaluate("foo");
       
        // (2) Apply function
        object result = foo.Call(3, 25);
    }
  
