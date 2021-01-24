    public class PurchaseOrderModel
    {
        public bool Deleted { get; set; }
    
        public TextColour TextColour => Deleted ? TextColour.Primary : TextColour.Secondary;
    }
