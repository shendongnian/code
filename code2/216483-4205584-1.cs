    class Class2
    {
        Dictionary<string, int> myActivity = new Dictionary<string, int>()
        {
            {"result", 5},
            {"total", 6}
        };
    
    
        public override Dictionary<string, int> activity
        {
            get
            {
                return myActivity;
            }
    
        }
    }
