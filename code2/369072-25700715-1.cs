        protected object CopyObj(Object obj)
        {
            return CloneObject(obj);
        }
        var cust1 = this.cts.Customers().Where(cc => cc.Id == 3).Include(cc => cc.Addresses).FirstOrDefault();
        var cust2 = CopyObj(cust1) as Customers;  
        //Cust2 now includes copies of the customer record and its addresses
    
     
