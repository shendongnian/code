    interface INewCustomer 
    {
       string CustomerName { get; set; }
       int CustomerId { get; set; }
       event EventHandler SaveClicked;
    }
