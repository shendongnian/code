    public enum A { One, Two, Three }
    public enum B { Four, Five, Six }
    
    public abstract class FooBase<T> where T : struct
    {
        T _enumVal;
    
        protected FooBase(T enumVal)
        {
            _enumVal = enumVal;
        }
    }
    
    public class Bar : FooBase<A>
    {
        public Bar(A enumVal):base(enumVal) {}
    }
    
    public class Bat : FooBase<B>
    {
        public Bat(B enumVal):base(enumVal) {}
    }
