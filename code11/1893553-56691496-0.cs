    public class StoreLogic
    {
        internal StoreLogic()
        {}
        public void PlaceOrder() {}
    }
    public class ShopLogic
    {
        internal ShopLogic() 
        {}
        public void FixWidget() { }
    }
    public class Client
    {
        public StoreLogic Store { get; }
        public ShopLogic Shop { get; }
        public Client(string LicenseKey)
        {
            this.Shop = new ShopLogic();
            this.Store = new StoreLogic();
        }
    }
