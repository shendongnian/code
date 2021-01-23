    namespace Framework.Test
    {
        [TestFixture]
        public class MyLongRunningTest : Log4NetLoggedTest
        {
            [Test]
            [Category("LongRunning")]
            public void ModelConvergesForS50()
            {
                Logger.Info("Starting test...");
              
                var obj = new SomeClass();
                obj.Logger = Logger;
                obj.DoSomething();
    
                // ...
            }
        }
    }
