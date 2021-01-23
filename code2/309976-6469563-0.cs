        private static readonly object _lock = new object();
    
        public int GetId()   
        {
          lock(_lock)
          {
            //You code to get ID here
          }
        }
