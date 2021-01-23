     public sealed class CollectionHolderSample
        {
            private readonly List<string> names;
            private readonly ReadOnlyCollection<string> readonlyNames;
    
            public CollectionHolderSample()
            {
                this.names = new List<string>();
                this.readonlyNames = new ReadOnlyCollection<string>(names); 
            }
    
            public ReadOnlyCollection<string> Items
            {
                get
                {
                    return this.readonlyNames;
                }
            }
    
            public void AddItem(string item)
            {            
                this.names.Add(item);
            }
        }
