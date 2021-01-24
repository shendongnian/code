public class A
{        
    public void Foo()
    {
      try
      {
        DoFoo();
      }
      catch
      {
      }
    }
    protected abstract void DoFoo();
}
Hence you will write:
public class B : A
{        
    protected override void DoFoo()
    {
    }
}
