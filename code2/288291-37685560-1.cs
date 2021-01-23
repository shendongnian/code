    public interface IHasMethod<T>
        where T : BaseClass
    {
        void MethodToCheck<T>(T, object);
    }
    public class Class1 : IHasMethod<DerivedClass>
    {
        public object MethodToCheck(DerivedClass d)
        {
        }
    }
