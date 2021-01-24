    public class Customer
    {
      private string _customerId;
    
      public string  CustomerId
      {
          get
    	  {
    		if (string.IsNullOrWhiteSpace(_customerId))
    			_customerId = Utilities.RandomString(6);
    			
    		return _customerId;
    	  }
      }
      public string CustomerName { get; set; }
    }
