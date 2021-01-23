    using NUnit.Framework;
    
    namespace Project.Tests
    {
        [TestFixture]
        public class MyTestClass
        {
            [Test]
            public void MyTestmethod()
            {
                var a = "a";
                var b = "a";
                Assert.AreEqual(a, b);
            }
        }
    }
