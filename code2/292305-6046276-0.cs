    public bool Foo(){
        Thread.Sleep(100000); // Do work
        return true;
    }
    public SomeMethod()
    {
        var fooCaller = new Func<bool>(Foo);
        // Call the method asynchronously
        var asyncResult = fooCaller.BeginInvoke(null, null);
        // Potentially do other work while the asynchronous method is executing.
        // Finally, wait for result
        asyncResult.AsyncWaitHandle.WaitOne();
        bool fooResult = fooCaller.EndInvoke(asyncResult);
        Console.WriteLine("Foo returned {0}", fooResult);
    }
