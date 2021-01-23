        public interface IFoo { }
    public abstract class AbsBaseBar
    {
        public IFoo TheFoo() { throw new NotImplementedException(); }
    }
    public class AbsFoo : IFoo { }
    public class AbsBar : AbsBaseBar
    {
        public AbsFoo TheFoo() { throw new NotImplementedException(); }
    }
    public class ConcreteFoo : AbsFoo { }
    public class ConcreteBar : AbsBar { } 
