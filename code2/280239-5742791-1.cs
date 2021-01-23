    public void MethodInSample()
    {
    Library lib = new Library();
    
    Action callback = () => { DoSomethingHere };
    Lib.ACTIVATE(1,1,callback);
    }
