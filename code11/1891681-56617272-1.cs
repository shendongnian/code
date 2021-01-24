        public static class GlobalVariable { public static string Local = "hi"; }
        public class BaseController
        {
            public virtual string Local { get { return GlobalVariable.Local; } }
        }
        [TestMethod]
        public void TestMethod() {
            var baseControllerMock = Substitute.For<BaseController>();
            baseControllerMock.Local.Returns("local");
        }
