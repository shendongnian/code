    [TestClass]
    public class MyTests
    {
        [TestMethod]
        public void TestParameterExpectation()
        {
            var mock = new Mock<IInterface>();
            mock.Setup(x => x.CallMe("expected"));
            CallIt("not expected", mock.Object);
            mock.VerifyAll();
        }
        public void CallIt(string value, IInterface callit)
        {
            callit.CallMe(value);
        }
    }
    public interface IInterface
    {
        void CallMe(string value);
    }
