    public class BaseClass : IRead {
      public BaseClass(int anInt) { AnInt = anInt; }
      public virtual int AnInt {
        get; protected set;
      }
    }
    public class Derived : BaseClass, IWrite {
      public Derived(int anInt) : base(anInt) { }
  
      int IWrite.AnInt {
        set { base.AnInt = value; }
      }
    }
