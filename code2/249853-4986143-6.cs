    class LocalTestClass
    {
        public int StaticTest( int setValue )
        {
            Local<int> test = Local<int>.Static( () => { } );
            int before = test.Value;
            test.Value = setValue;
            return before;
        }
    
        public int InstanceTest( int setValue )
        {
            Local<int> test = Local<int>.Instance( () => this );
            int before = test.Value;
            test.Value = setValue;
            return before;
        }
    }
    
    [TestMethod]
    public void LocalStaticTest()
    {
        LocalTestClass instance1 = new LocalTestClass();
        LocalTestClass instance2 = new LocalTestClass();
    
        instance1.StaticTest( 10 );
        Assert.AreEqual( 10, instance2.StaticTest( 20 ) );
        Assert.AreEqual( 20, instance1.StaticTest( 30 ) );
    }
    
    [TestMethod]
    public void LocalInstanceTest()
    {
        LocalTestClass instance1 = new LocalTestClass();
        LocalTestClass instance2 = new LocalTestClass();
        instance1.InstanceTest( 10 );
        Assert.AreEqual( 10, instance1.InstanceTest( 20 ) );
        instance2.InstanceTest( 50 );
        Assert.AreEqual( 20, instance1.InstanceTest( 30 ) );
    }
