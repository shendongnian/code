    public class classA
    {
        private classB b = new classB();
    
        public void methodA()
        {
            // Read b.myVar for missing collection item
    
            lock (b)
            {
                // Check for missing collection item again. If not missing, leave lock
                // Operation without calling methodA() or methodB() 
                // Read b.myVar
                // Update b.myVar with new array item
            }
        }
    
        public void methodB()
        {
            // Read b.myVar for missing collection item
            lock (b)
            {
                // Check for missing collection item again. If not missing, leave lock
                // Operation without calling methodA() or methodB() 
                // Read b.myVar
                // Update b.myVar with new array item
            }
        }
    }
