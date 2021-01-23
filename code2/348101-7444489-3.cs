     public sealed class CollectionHolderSample
        {
            private readonly List<string> names;
    
            public CollectionHolderSample()
            {
                this.names = new List<string>();
            }
    
            public ReadOnlyCollection<string> Items
            {
                get
                {
                    return this.names;
                }
            }
    
            public void AddItem(string item)
            {            
                this.names.Add(item);
            }
        }
