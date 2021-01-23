    [SetUpFixture]
    public class PreTestSetup
    {
        [SetUp]
        public void Setup()
        {
            PackUriHelper.Create(new Uri("reliable://0"));
            new FrameworkElement();
            System.Windows.Application.ResourceAssembly = typeof (App).Assembly;
        }
    }
