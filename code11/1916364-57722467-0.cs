    [assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]
    // Notice the assembly bracket, this can be compatible or incompatible with how your code is built
    namespace UnitTestProject1
    {
        [TestClass]
        public class TestClass1
        {
            [TestMethod]
            [DoNotParallelize] // This test will not be run in parallel
            public void TestPrice_5PercentTax() => //YourTestHere?;
            
            [TestMethod]
            [DoNotParallelize] // This test will not be run in parallel
            public void TestPrice_10PercentTax() => //YourTestHere?;            
            
            [TestMethod]
            [DoNotParallelize] // This test will not be run in parallel
            public void TestPrice_NoTax() => //YourTestHere?;
    
            [TestMethod]
            public void TestInventory_Add10Items() => //YourTestHere?;
    
            [TestMethod]
            public void TestInventory_Remove10Items() => //YourTestHere?;
        }
    }
