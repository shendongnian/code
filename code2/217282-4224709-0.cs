    public interface IDependency
    {
    }
    public abstract class A
    {
        protected IDependency _dep;
        protected A(IDependency dep)
        {
            _dep = dep;
        }
    }
    public class B : A
    {
        public B(IDependency dep) : base(dep)
        {
        }
    }
