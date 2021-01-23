    public void ZeroReceives12()
    {
        int input;
        mockReceivable.Setup(x => x.Process(It.IsAny<Foo>())
                  .Callback(y => foo = y);
        bar.SomeMethod(0);
        // ensure input is what you expect
    }
    
