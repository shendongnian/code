    public interface IFoo { }
    
    public class ConcreteFoo { }
    
    public abstract class Base
    {
      private IFoo m_Foo;
    
      public Base(IFoo x) { m_Foo = x; }
    
      public IFoo Foo { get { return m_Foo; } }
    }
    
    public class Derived
    {
      public Derived(ConcreteFoo x) : base(x) { }
    
      public new ConcreteFoo Foo { get { return (ConcreteFoo)base.Foo; } }
    }
