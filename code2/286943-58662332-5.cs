    public static void SomeTest()
    {
        var myObject = new object();
        var wr = new WeakReference(myObject);
        GC.Collect();
        Assert.True(wr.IsAlive, "This could fail in Release Mode!");
    }
