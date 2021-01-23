    class ThingsCollection
    {
        ReadOnlyCollection<Thing> _things;
    
        public ThingsCollection()
        {
            Thing[] things = CreateThings();
            _things = Array.AsReadOnly(things);
        }
    
        public IList<Thing> Things
        {
            get { return _things; }
        }
        protected virtual Thing[] CreateThings()
        {
            // Whatever you want, obviously.
            return new Thing[0];
        }
    }
