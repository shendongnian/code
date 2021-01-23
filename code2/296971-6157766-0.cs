    public class TestThreading
    {
        private System.Object lockThis = new System.Object();
    
        public void Process()
        {    
            lock (lockThis)
            {
                // Access thread-sensitive resources.
            }
        }    
    }
