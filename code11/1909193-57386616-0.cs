    using System.Collections.Generic;
    using NSubstitute;
    using Xunit;
    public interface ISomeType {
        List<string> MyFunction();
    }
    public class SampleFixture {
        [Fact]
        public void ReturnList() {
            var _mockedObject = Substitute.For<ISomeType>();
            var myList = new List<string> { "hello", "world" };
            _mockedObject.MyFunction().Returns(myList);
            // Checking MyFunction() now stubbed correctly:
            Assert.Equal(new List<string> { "hello", "world" }, _mockedObject.MyFunction());
        }
    }
