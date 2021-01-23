    Class ThreadClass
    {
        private static object myMutex = new object();
    
        public ThreadFunction()
        {
            // Wait until it is safe to enter.
            lock(myMutex)
            {
                // critical code
            }
            // the mutex is automatically released after leaving the block.
        }
    }
    
    Class MotherClass
    {
        ThreadClass one = new ThreadClass(); // first instance
        Threadclass two = new ThreadClass(); // second instance
    
        // Assign the Thread function to run on separate Thread
    }
