    public interface ISomeInterface
    {
        void SomeMethod<A>(A someArgument);
    }
    public class SomeClass : ISomeInterface
    {
        public void SomeMethod<TA>(TA someArgument) where TA : SomeClass
        {
            
        }
    }
