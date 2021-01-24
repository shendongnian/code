    public interface ITestDummy
    {
        void Run(String arg1, Int32 arg2);
    }
    public class UnitTest
    {
        [Fact]
        public void Test1()
        {   
            var testDummy = Substitute.For<ITestDummy>();
            
            Action<String, Int32> action = testDummy.Run;  
            Func<String, Int32, Unit> func = action.ToFunc();
            var result = func("foobar", 123);
            testDummy.Received().Run("foobar", 123);
            Assert.Equal(result, Unit.Default);
        }
    }
