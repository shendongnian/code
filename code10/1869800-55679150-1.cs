    public class InventoryViewModel
        {
            public InventoryViewModel()
            {
                this.StorageUnits = new List<StorageUnit>();
            }
            public int Id { get; set; }
            public string Name { get; set; }
    
            public ICollection<StorageUnit> StorageUnits { get; set; }
        }
