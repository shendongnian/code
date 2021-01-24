    public interface IRepresentsWhatThePrivateMethodDid
    {
        string MethodThatNeedsItsOwnTests(int value);
    } 
    public class RefactoredClass
    {
        private readonly IRepresentsWhatThePrivateMethodDid _dependency;
        public RefactoredClass(IRepresentsWhatThePrivateMethodDid dependency)
        {
            _dependency = dependency;
        }
        public string DoSomething(int value)
        {
            return _dependency.MethodThatNeedsItsOwnTests(value);
        }
    }
