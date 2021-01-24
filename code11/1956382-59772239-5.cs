    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var obj = new SomeClass();
            var mock = ( (IMockable<SomeClass>) obj ).CreateMock();
            mock.Setup( m => m.GimmeSomeData() ).Returns( () => new List<string> { "3", "1", "2" } );
            
            var resultList = obj.GimmeSomeData();
            Console.WriteLine( "Result: {0}", string.Join( ", ", resultList ) );
        }
    }
