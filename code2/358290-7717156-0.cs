    [Test]
    public void Do_WhenCalled_CallsMyAbstractMethod()
    {
    	var sutMock = new Mock<MyAbstractClass>() { CallBase = true };
        sutMock.Object.Do();
        sutMock.Verify(x => x.MyAbstractMethod());
    }
    
    public abstract class MyAbstractClass
    {
        public void Do()
        {
            MyAbstractMethod();
        }
    
        public abstract void MyAbstractMethod();
    }
