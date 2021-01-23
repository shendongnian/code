    public static class clsCounter
    {
        private static int count;
        public static int Counter
        {
            get { 
                   Debug.WriteLine("Counter viewed"); 
                   return count; 
                }
            set { 
                   Debug.WriteLine("Counter Changed from {0} to {1}", count, value);
                   count = value; 
                }
        }
    }
