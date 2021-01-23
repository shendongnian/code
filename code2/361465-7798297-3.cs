    public interface IFoo<T> {
        T Method();
    }
    public abstract class Base : IFoo<Base>
    {
        Base IFoo<Base>.Method()
        {
            return this;
        }
    }
    public class Derived1 : IFoo<Derived1>
    {
        public Derived1 Method()
        {
            // If you need to call the base version, you'll
            // need ((IFoo<Base>)this).Method()
            return this;
        }
    }
