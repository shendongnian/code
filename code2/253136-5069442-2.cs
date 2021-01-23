    public class Customer
    {
        private int _customerID;
        public int CustomerID
        {
            get { return _customerID; }
            set { throw new exception("Cannot set value!"); }
        }
        
    }
