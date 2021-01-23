    public class Otherclass{
        ManualResetEvent mre = new ManualResetEvent(false);
        public void PostMessage(string input)
        {
             // Other stuff here...
             mre.Set(); // Allow the "wait" to continue
        }    
        public void Wait()
        {
              mre.WaitOne(); // Blocks until the set above
        }
    }
