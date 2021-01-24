public class MyClass
{
   readonly IMockedClass mockedClass = null;
   public MyClass(IMockedClass mockedClass)
   {
      this.mockedClass = mockedClass();
   }
   public string Function2()
   { /* return a string here */ }
}
and your test code will be:
public string Function2Test()
   {
      var returnMock = new List<string>() { "1", "2", "3" };
      var mockMockedClass = new Mock<IMockedClass>();
      mockMockedClass.Setup(x => x.Function1()).Returns(returnMock);
      var myClass = new MyClass(mockMockedClass.Object);
      var result = myClass.Function2();
      ...
   }
