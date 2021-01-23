    //
    // This will not compile because members have been defined more than once
    public class Bet
    {
        // You can declare smart properties with default initializers
        // by not declaring a body for the get/set accessors
        public decimal Amount
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        // OR, you can declare private variables and expose them
        // publicly via get/set accessors. This gives flexibility
        // in internal manipulation (sometimes) but creates more code
        private decimal _amount = 0M;
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        private string _description = string.Empty;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
