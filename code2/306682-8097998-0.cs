    [ContractClassFor(typeof(IX))]
    class IXContract
    {
        [ContractInvariantMethod]
        void Invariant() { }
    }
    [ContractClass(typeof(IXContract))]
    public interface IX { event EventHandler b; }
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public void MyTest()
        {
            var a = new Mock<IX>();
            a.Raise(x => x.b += null);
        }
    }
