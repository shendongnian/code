    public class Result : IResult
    {
        #region IResult Members
        private readonly Func<bool> _testMethod;
        public bool TestPassed
        {
            get { return _testMethod(); }
        }
        private readonly Action _actionMethod;
        public void Execute()
        {
            _actionMethod();
        }
        #endregion
        public Result(Func<bool> testMethod, Action actionMethod)
        {
            _testMethod = testMethod;
            _actionMethod = actionMethod;
        }
    }
