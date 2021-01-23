    [SetUpFixture]
    public class Config
    {
        [SetUp]
        public void SetUp()
        {
            // indicate to Grensesnitt that the Foo class
            // doesn't have a default constructor and that 
            // it is up to you to provide an instance
            GrensesnittObjectLocator.Register<Foo>(() =>
            {
                return new Foo("abc");
            });
        }
    }
