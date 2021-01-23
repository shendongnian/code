    public class SomeLogicClass
    {
       public event EventHandler SomethingDone;
    
       protected virtual void OnSomethingDone()
       {
          if( SomethingDone != null )
          {
               SomethingDone(this, EventArgs.Empty);
          }
       }
    
       public void DoSomething()
       {
           // Do some work.
           OnSomethingDone();
       }
    }
