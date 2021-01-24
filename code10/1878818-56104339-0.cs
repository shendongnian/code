    public struct InventoryAmountOrSoldAmount 
    {
        public InventoryAmountOrSoldAmount( InventoryAmount ia => this.InventoryAmount = ia;
        public InventoryAmountOrSoldAmount( SoldAmount sa => this.SoldAmount = sa;
       public InventoryAmount { get;}
       public SoldAmount { get;}
