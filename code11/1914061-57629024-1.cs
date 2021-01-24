    [TestClass]
    public class Configuration 
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext) 
        {
            Console.Write(testContext.Properties["Name"]); // Outputs "Dan"
            // The TestContext object will be modified and the updated value 
            // will be ready the next time it's retrieved
            testContext.Properties["Name"] = "John"; 
        }
    }
