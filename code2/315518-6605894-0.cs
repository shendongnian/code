    class LocationList : IEnumerable<Location>
    {
        List<Location> _list; // initialize somewhere
    
        public IEnumerator<Location> GetEnumerator() 
        {
             return _list.GetEnumerator();
        }
    
        IEnumerable.IEnumerator GetEnumerator() 
        {
             return this.GetEnumerator();
        }
        // ... your other custom properties and methods
    }
