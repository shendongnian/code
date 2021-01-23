    public interface ILogger
    {
        void Log(string value);
        void Log(object value);
    }
    
    public class LoggerTests
    {
        public void FakeGetCallsExample()
        {
            var logger = A.Fake<ILogger>();
    
            logger.Log("whatever");
    
            var callsToLog = Fake.GetCalls(logger).Where(x => x.Method.Name.Equals("Log"));
                
            // Asserting with NUnit.
            Assert.That(callsToLog(), Is.Not.Empty);
        }
    
        // The following does not work as of now but I'll seriously consider
        // implementing it:
        public void AnyCallToWithCallSpecificationExample()
        {
            var logger = A.Fake<ILogger>();
    
            logger.Log("whatever");
    
            // I would add a "filtering" method to the Any.CallTo-syntax:
            Any.CallTo(logger).WhereCallMatches(x => x.Method.Name.Equals("Log")).MustHaveHappened();
    
            // It would also enable an extension method:
            Any.CallTo(logger).ToMethodNamed("Log").MustHaveHappened();
        }
    }
