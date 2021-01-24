    public class RefactoredClass
    {
        private readonly Func<int, string> _dependency;
        public RefactoredClass(Func<int, string> dependency)
        {
            _dependency = dependency;
        }
        public string DoSomething(int value)
        {
            return _dependency(value);
        }
    }
