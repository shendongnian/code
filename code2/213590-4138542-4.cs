    class Customer              
    {         
        private CustomerDL customerData = new CustomerDL(); 
              
        public string Names { get; set; }            
              
        public string FillNames()
        {
            this.Names = customerData.GetNames();
        }  
    }              
