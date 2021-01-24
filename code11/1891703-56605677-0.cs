    class Test
    { 
        private readonly List<string> id = new List<string>();
        // Return a copy of our private list
        public List<string> Id => id?.ToList();
        public void AddId(string newId)
        {
            id.Add(newId);
            // do something else here when we add a new item
        }
    }
