    public class InventoryDetailsViewModel
    {
      public InventoryModel Inventory { get; set; }
      public ICollection<InventoryActionsModels> Actions { get; set; }
    }
