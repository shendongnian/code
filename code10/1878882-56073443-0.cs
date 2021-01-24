    internal class Third
    {
        public event Action Updated;
    
        public Third()
        {
            // ...
            if(Updated != null)
                Updated();
        }
    }
