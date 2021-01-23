    class ThreadTest{
    Object myLock = new Object();
    ...
    void Go(){
      lock(myLock){
         if(!done)
         {
             done = true;
             Console.WriteLine("Done");
         }
       }
    }
   
