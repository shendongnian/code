    public class DoesNothingBase
    {
      public void NonVirtualFooBox(object arg) { }
      public void NonVirtualFooNonBox(int arg) { }
      public virtual void FooBox(object arg) { }
      public virtual void FooNonBox(int arg) { }
    }
    public class DoesNothing : DoesNothingBase
    {
      public override void FooBox(object arg) { }
      public override void FooNonBox(int arg) { }
    }
