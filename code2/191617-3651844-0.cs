    // Don't do this in all methods of your custom control!
    public void Foo()
    {
      if (!CheckAccess())
      {
        Dispatcher.Invoke(()=> Foo()); // Transit to UI Thread
        return;
      }
      // .. do work in UI.
    }
