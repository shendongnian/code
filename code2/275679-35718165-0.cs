    internal class Foo
    {
        public Foo()
        {
        }
        public int Bar()
        {
            var x = new MyDataContext();
            return x.MyFunction(null, "5");
        }
    }
    public class MyDataContext : DataContext
    {
       //
        public int MyFunction(int? a, string b)
        {
            if(a == null)
            {
                throw new Exception();
            }
            return 0;
        }
    }
    [TestMethod, Isolated]
    public void TestMyDataContext()
    {
         //Arrange
         var fakeDC = Isolate.Fake.AllInstances<MyDataContext>();
         Isolate.WhenCalled(() => fakeDC.MyFunction(null, "5")).WithExactArguments().WillReturn(6);
    
         //Act
         var foo = new Foo();
         var res = foo.Bar();
    
         //Assert
         Assert.AreEqual(6, res);
     }
