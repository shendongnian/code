    private CustomerOrderItem _HighestValueOrderItem = null;
    public CustomerOrderItem HighestValueOrderItem { 
    get{
       if(this.CustomerOrderItems.Any() && _HighestValueOrderItem){
            _HighestValueOrderItem =  this.CustomerOrderItems.OrderByDescending(i => i.SalesPrice).FirstOrDefault();
            return  _HighestValueOrderItem;
       } else {
          return new CustomerOrderItem();
       }
    }
    }
