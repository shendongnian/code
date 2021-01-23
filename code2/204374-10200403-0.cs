    public void UnitTestX()
    {
        // use this to block the test thread until Dispose() is run
        ManualResetEvent mre = new ManualResetEvent(false);
        bool disposeCalled = false;
        bool getCalled = false;
        ClassX classX = new ClassX();
        var data = new SIClassXData
                       {
                           Dispose = () => { 
                              disposeCalled = true; 
                              mre.Set(); // release the test thread now
                           },
                           Get = () => getCalled = true,
                           ClassXGet = () => classX
                       };
        MDataLayerFactory.CreateDataLayerObject(() => (IClassXData)data);
        Assert.IsTrue(mre.WaitOne(1000)); // give it a second to fire
        Assert.IsTrue(disposeCalled);
        Assert.IsTrue(getCalled);
    }
