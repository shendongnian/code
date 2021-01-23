    class Order
    {
        public virtual long GetOrderNumber { return nextOrderNumber; }
    }
    
    class ExpressOrder : Order
    {
        public override long GetOrderNumber { return nextOrderNumber + 1000000; }
    }
