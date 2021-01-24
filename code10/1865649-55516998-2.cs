    public interface ISmallSegregatedInterface
    {
        void DoJustWhatMyClassNeeds();
    }
    public class TheImplementation : ISmallSegregatedInterface
    {
        private readonly FrameworkClassWithLotsOfMembers _inner;
        public TheImplementation(FrameworkClassWithLotsOfMembers inner)
        {
            _inner = inner;
        }
 
        public void DoJustWhatMyClassNeeds()
        {
            _inner.CallSomeMethod();
        }
    }
