using NUnit.Framework;
using System;
namespace TestsSetup
{
    [TestFixture]
    public class CWTestSuite : TestSetup
    {
        [TestFixture]
        public class SuiteSetup
        {
            static private bool isLoggedOn;
            [OneTimeSetUp]
            public void TestSuiteSetup()
            {
                if (isLoggedOn == false)
                {
                    Console.WriteLine("Loggin happens here");
                    isLoggedOn = true;
                }
            }
        }
    }
    [SetUpFixture]
    public class TestSetup
    {
        [OneTimeTearDown]
        public void Teardown()
        {
            Console.WriteLine("Login out happens here");
        }
        [TestFixture]
        public class Testing
        {
            [Test]
            public void Test1()
            {
                Console.WriteLine("All tests for this product has been executed");
            }
        }
    }
}
any of the test.cs matching the following format
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using static TestsSetup.CWTestSuite;
namespace TestSetup
{
    [TestFixture]
    public class UserManagerTests : SuiteSetup
    {
        [Test]
        public void Test3()
        {
            Console.WriteLine("Assertion");
            Assert.AreEqual(1, 1);
        }
        [Test]
        public void Test4()
        {
            Console.WriteLine("Assertion");
            Assert.AreEqual(1, 1);
        }
    }
}
1. I could not get rid of the ```[TestFixture]``` within the ```[TestFixture]``` (Setup.cs/public class CWTestSuite). If I delete it it will hit the ```[OneTimeTearDown]``` after running the tests in a class.
2. I had to add a flag on the login steps as that ```[OneTimeSetUp]``` is called at the beginning of every set of tests.
3. The only way I found to trigger the ```[OneTimeTearDown]``` was to add a ```[TestFixture]/[Test]``` afterwards. it is called at the very end and it may just print a console.log but it needs to be there and it needs to be called.
