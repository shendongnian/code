        private List<string> _items = new List<string>();         
    
        public ReadOnlyCollection<string> Items
    
        {
    
            get { return _items.AsReadOnly(); }
    
            private set { _items = value }
    
        }
