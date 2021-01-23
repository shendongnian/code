    [Test]
    public void TestMe()
    {
        var count = 0;
        var mock = new Mock<IMyClass>();
        mock.Setup(a => a.MyMethod()).Callback(() =>
            {
                count++;
                if(count == 1)
                    throw new ApplicationException();
            });
        Assert.Throws(typeof(ApplicationException), () => mock.Object.MyMethod());
        Assert.DoesNotThrow(() => mock.Object.MyMethod());
    }
    
    public interface IMyClass
    {
        void MyMethod();
    }
