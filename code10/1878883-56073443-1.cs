    internal class Third
    {
        public event Action Updated;
    
        public Third()
        {            
        }
        public void Init()
        {
            // ...
            if(Updated != null)
                Updated();
        }
    }
    Third t = new Third();
    t.Updated += OnThirdUpdated;
    t.Init();
