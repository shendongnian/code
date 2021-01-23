    using (var a = new DisposableObjectA())
    {
        using (var b = new DisposableObjectB())
        {
             using (var c = new DisposableObjectC())
             {
                  SomeFunction(a,b,c);
             }
        }
    }
