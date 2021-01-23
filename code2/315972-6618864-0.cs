    class YourClass : IEnumerable<SomeClass>
    {
        List<SomeClass> list = ...
    
        public IEnumerator<SomeClass> GetEnumerator() 
        {
            return list.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator(); 
        }
    }
