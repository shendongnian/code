    using System;
    using NUnit.Framework;
    using Moq;
    
    namespace MyStuff
    {
        [TestFixture]
        public class SomeClassTester
        {
            [Test]
            public void TestIsThisPossible()
            {
                var mockUsefulService = new Mock<IUsefulService>();
                mockUsefulService.Setup(a => a.GetSomethingGood(It.IsAny<object>()))
                    .Returns((object input) => string.Format("Mocked something good: {0}", input));
    
                var someClass = new SomeClass {Service = mockUsefulService.Object};
                Assert.AreEqual("Mocked something good: GOOD!", someClass.IsThisPossible("GOOD!"));
            }
        }
        public interface IUsefulService
        {
            string GetSomethingGood(object theObject);
        }
    
        public class SomeClass
        {
            //empty constructor
            public SomeClass() { }
    
            //dependency
            public IUsefulService Service { get; set; }
    
            public string IsThisPossible(Object someObject)
            {
                //do some stuff
    
                //I want to mock Service and the result of GetSomethingGood
                var result = Service.GetSomethingGood(someObject);
                return result;
            }
        }
    }
