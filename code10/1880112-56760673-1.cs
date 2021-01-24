[SetUpFixture]
    public class AssemblySetup
    {
        [OneTimeSetUp]
        public static void Setup()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("de-AT");
          
        }
        [OneTimeTearDown]
        public void EndReport()
        {
              _extent.Flush();
         }
    }
