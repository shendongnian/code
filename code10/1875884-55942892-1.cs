    public class RefactoredClass
    {
        private readonly IRepresentsWhatThePrivateMethodDid _dependency;
        public RefactoredClass(IRepresentsWhatThePrivateMethodDid dependency)
        {
            _dependency = dependency;
        }
        public void DoSomething(int value)
        {
            _dependency.MethodThatNeedsItsOwnTests(value);
        }
    }
    public interface IRepresentsWhatThePrivateMethodDid
    {
        void MethodThatNeedsItsOwnTests(int value);
    }   
