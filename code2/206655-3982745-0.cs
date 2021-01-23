    internal class Class1
    {
       internal virtual void SomeFunc()
       {
          // no guarantee this code will run
       }
    
    
       internal void MakeSureICanDoSomething()
       {
          // do pre stuff I have to do
    
          ThisCodeMayNotRun();
    
          // do post stuff I have to do
       }
    
       internal virtual void ThisCodeMayNotRun()
       {
          // this code may or may not run depending on 
          // the derived class
       }
    }
