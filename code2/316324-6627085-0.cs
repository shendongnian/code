    public partial class HierarchicalItem
        {
            public INotifyCollectionChanged ContainingCollection { get; private set; }
    
            public HierarchicalItem Parent
            {
                get
                {
    
                    return (ContainingCollection != null)
                        ? ((ObservableHierarchicalCollection<T>)ContainingCollection).Owner
                        : null;
    
                }
            }
    
        }
