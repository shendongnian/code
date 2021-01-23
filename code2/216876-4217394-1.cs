    class Customer
    {
        private object _sync = new object();
    
        public string DoSomething( string xml )
        {
            lock (_sync)
            {
                // put your logic here...
            }
        }
    }
