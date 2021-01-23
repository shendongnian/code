    class ThreadTest{
    Object myLock = new Object();
    ...
    void Go(){
      lock(myLock){
         if(!done)
         {
             done = true;
         }
       }
       //This line of code does not belong inside the lock.
       Console.WriteLine("Done");
    }
