C#
async Task MyTest()
{
  var mock = new Mock<MyService>();
  var mockData = new[] { "first", "second" };
  mock.Setup(x => x.CallSomethingReturningAsyncStream()).Returns(mockData.ToAsyncEnumerable());
  var sut = new SystemUnderTest(mock.Object);
  var result = await sut.MyMethodIWantToTest();
  // TODO: verify `result`
}
