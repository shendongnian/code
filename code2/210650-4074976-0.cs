    // Northwnd inherits from System.Data.Linq.DataContext.
 
        Northwnd nw = new Northwnd(@"northwnd.mdf");
        
        var cityNameQuery =
            from cust in nw.Customers
            where cust.City.Contains("London")
            select cust;
        
        foreach (var customer in cityNameQuery)
        {
            if (customer.City == "London")
            {
                customer.City = "London - Metro";
            }
        }
        // you must call this this commit the changes
        nw.SubmitChanges();
