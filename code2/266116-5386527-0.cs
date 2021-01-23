    public interface ITest
    {
        void SomeMethod();
    }
    internal abstract class SuperA : ITest
    {
        public abstract void SomeMethod();
    }
    class A : SuperA
    {
        public sealed override void SomeMethod()
        {
        }
    }
