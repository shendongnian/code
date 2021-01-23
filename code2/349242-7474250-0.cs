    public CompositeClass
    {
        private ResultClass _resultClass = new ResultClass();
        public IList<Item> Results
        {
            get { return _resultClass.Results; }
            set { _resultClass.Results = value; }
        }
        
        public int TotalResults
        {
            get { return _resultClass.TotalResults; }
            set { _resultClass.TotalResults = value; }
        }
        //
        // New Property
        //
        public string Description { get; set; }
    }
