    public class classA
    {
        private classB b = new classB();
    
        public void methodA()
        {
            lock (b)
            {
                // Operation without calling methodA() or methodB() 
                // Read b.myVar
                // Update b.myVar
            }
        }
    
        public void methodB()
        {
            lock (b)
            {
                // Operation without calling methodA() or methodB()
                // Read b.myVar
                // Update b.myVar
            }
        }
    }
