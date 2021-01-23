    public virtual class MyBaseClass
    {
       public virtual boolean IsMethodXOverridden { get { return false; } }
       public virtual void MethodX()
       {
          DoSomething();
       }
    }
    public sealed class MySuperClass : MyBaseClass
    {
       public override bool IsMethodXOverridden { get { return true; } }
       public override void MethodX()
       {
          DoSomethingElse();
       }
    }
