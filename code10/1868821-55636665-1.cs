    public class TestException : Exception
    {
        private List<ArgWrapper> parameters = new List<ArgWrapper>();
        public IEnumerable<ArgWrapper> Parameters => parameters;
        public TestException(params ArgWrapper[] passedParameters)
        {
            parameters.AddRange(passedParameters);
        }
    }
