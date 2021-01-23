    // This class simulates the use of two different
    // thread safe resources and how to lock them
    // for thread safety but not block other
    // threads getting different resources.
    public class SmartLocking
    {
        private string StrResource1 { get; set; }
        private string StrResource2 { get; set; }
     
        private object _Lock1 = new object();
        private object _Lock2 = new object();
     
        public void DoWorkOn1( string change )
        {
            lock (_Lock1)
            {
                _Resource1 = change;
            }
        }
     
        public void DoWorkOn2( string change2 )
        {
            lock (_Lock2)
            {
                _Resource2 = change2;
            }
        }
    }
