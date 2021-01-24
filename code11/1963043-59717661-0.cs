    public class MyClassTests {
        private Mock<IMyService> _serviceMock = new Mock<IMyService>();
    
        public void UnitTest01() {
            // Arrange
            MyObject expected = new MyObject {
                SomeProperty01 = "One",
                SomeProperty02 = 2,
                Timestamp = DateTime.Now
            };
            MyObject actual = null;
            //Setup the mock to capture the passed argument in a callback
            _serviceMock
                .Setup(x => x.DoSomething(It.IsAny<MyObject>())
                .Callback(MyObject arg => { actual = arg; });
    
            MyClass myClass = new MyClass(_serviceMock.Object);
            string input = Newtonsoft.Json.JsonConvert.SerializeObject(expected);
            // Act
            myClass.DoWork(input);
    
            // Assert using FluentAssertions
            actual.Should().BeEquivalentTo(expected);
        }
    }
