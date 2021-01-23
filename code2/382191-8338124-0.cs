    public void SomeMethod()
    {
        using(IDisposable myDisposable = new SomeClassThatImplementsIDisposable())
        {
            //Do something with your disposable...
        }
        //And, it's out of scope here
    }
