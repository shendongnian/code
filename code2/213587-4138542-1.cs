    class Customer              
    {                       
        public string Names { get; set; };            
              
        public string FillNames()
        {
            CustomerDL customerData = new CustomerDL();
            this.Names = customerData.GetNames();
        }  
    }              
