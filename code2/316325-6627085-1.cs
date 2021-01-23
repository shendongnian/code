    public partial class HierarchicalItem
        {
            public INotifyCollectionChanged ContainingCollection { get; private set; }
    
            public HierarchicalItem Parent
            {
                get
                {
    
                    return (ContainingCollection != null)
                        ? ((ObservableHierarchicalCollection<HierarchicalItem>)ContainingCollection).Owner
                        : null;
    
                }
            }
    
        }
