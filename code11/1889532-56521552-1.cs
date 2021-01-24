    [TestClass]
    public class TestSomeFunction()
    {
        public IComponentContext ComponentContext { get; set; }       
    
        [TestInitialize]
        public void Initialize()
        {
           //Registering all dependencies required for unit testing
           this.ComponentContext = builder.Build(); //You have not build your container in your question
        }
    
        [TestMethod]
        public void Testfunction()
        {
           //Resolve perticular dependency
           var _logger = containerFactory.Resolve<ILogger>();   
           //Test my function
           //use _logger 
        }
    }
