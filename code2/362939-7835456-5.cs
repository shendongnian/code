    Class ThreadClass
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        public ThreadFunction()
        {
            // critical code
        }
    }
    
    Class MotherClass
    {
        ThreadClass one = new ThreadClass(); // first instance
        Threadclass two = new ThreadClass(); // second instance
    
        // Assign the Thread function to run on separate Thread
    }
