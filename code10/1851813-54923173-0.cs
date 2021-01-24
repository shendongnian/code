    public class TestFactory
    {
        public ITestInterface Create(string flavor)
        {
            if (flavor == "concrete")
            {
                return new TestImplementation();
            }
            else
            {
                return new OtherTestImplementation();
            }
        }
    }
