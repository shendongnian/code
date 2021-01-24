    namespace Some.Common.Namespace
    {
        [SetUpFixture]
        public class TestSetup
        {
            [OneTimeSetUp]
            public void Setup()
            {
                Console.WriteLine("Login in");
            }
            [OneTimeTearDown]
            public void Teardown()
            {
                Console.WriteLine("Login out");
            }
        }
        public class UserManagerTests
        {
            [Test]
            public void Test1()
            {
                Console.WriteLine("Assertion");
                Assert.AreEqual(1, 1);
            }
            [Test]
            public void Test2()
            {
                Console.WriteLine("Assertion");
                Assert.AreEqual(1, 1);
            }
        }
        public class ReportTests
        {
            [Test]
            public void Test1()
            {
                Console.WriteLine("Assertion");
                Assert.AreEqual(1, 1);
            }
            [Test]
            public void Test2()
            {
                Console.WriteLine("Assertion");
                Assert.AreEqual(1, 1);
            }
        }
    }
