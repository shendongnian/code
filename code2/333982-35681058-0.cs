    [TestMethod, Isolated]
    public void TestWidget()
    {
        Isolate.WhenCalled((int n) => Widget.GetPrice(n)).AndArgumentsMatch((n) => n == 123).WillReturn("A");
                
        bool wasCalledWith456 = false;
    
        Isolate.WhenCalled(() => Widget.GetPrice(456)).WithExactArguments().DoInstead((context) =>
        {
            wasCalledWith456 = true;
            context.WillCallOriginal();
            return null;
        });
    
        Assert.AreEqual("A", Widget.GetPrice(123));
        Widget.GetPrice(234);
        Widget.GetPrice(345);
        Widget.GetPrice(456);
    
        Assert.IsFalse(wasCalledWith456);
    }
