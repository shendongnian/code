    using System.Collections.Generic;
    using Moq;
    using Xunit;
    namespace XUnitTestProject1
    {
        public interface TestInterface
        {
            List<string> TestMethod(List<string> ids);
            List<string> TestMethod(List<string> ids, bool testBool);
        }
        public class UnitTest1
        {
            [Fact]
            public void Foo()
            {
                List<string> testReturnData = new List<string>();
                Mock<TestInterface> mockedInterface = new Mock<TestInterface>();
                mockedInterface
                    .Setup(d => d.TestMethod(It.IsAny<List<string>>(), true)).Returns(testReturnData);
                List<string> someValidInput = new List<string>();
                var testInterfaceInstance = mockedInterface.Object;
                List<string> returnData = testInterfaceInstance.TestMethod(someValidInput, true);
            }
        }
    }
