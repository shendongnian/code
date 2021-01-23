    public void SomeMethod()
    {
        IDisposable myDisposable = new SomeClassThatImplementsIDisposable();
        try 
        {    
            //Do something with your disposable...
        }
        finally
        {
            myDisposble.Dispose();
        }
        //And, it's out of scope here
    }
