    public class BaseClass
    {
      public void WriteNum()
      {
        Console.WriteLine(12);
      }
      public virtual void WriteStr()
      {
        Console.WriteLine("abc");
      }
    }
    
    public class DerivedClass : BaseClass
    {
      public new void WriteNum()
      {
        Console.WriteLine(42);
      }
      public override void WriteStr()
      {
        Console.WriteLine("xyz");
      }
    }
    /* ... */
    BaseClass isReallyBase = new BaseClass();
    BaseClass isReallyDerived = new DerivedClass();
    DerivedClass isClearlyDerived = new DerivedClass();
    
    isReallyBase.WriteNum(); // writes 12
    isReallyBase.WriteStr(); // writes abc
    isReallyDerived.WriteNum(); // writes 12
    isReallyDerived.WriteStr(); // writes xyz
    isClearlyDerived.WriteNum(); // writes 42
    isClearlyDerived.writeStr(); // writes xyz
