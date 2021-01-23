    [TestClass]
    public class GlobalInterfacesUnitTest
    {
        [ImportMany(AllowRecomposition = true)]
        Lazy<IComponentGui, IImportComponentGuiCapabilites>[] Senders {get;set;}
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
