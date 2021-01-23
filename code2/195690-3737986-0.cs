    class Cell{
    
     private static Mutex mut = new Mutex();
        
        private static void SetResource(...)
        {
            // Wait until it is safe to enter.
            mut.WaitOne();
    
            //change cell contents here...
    
            // Release the Mutex.
            mut.ReleaseMutex();
        }
       }
