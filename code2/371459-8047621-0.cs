    // Get DataContext from page context
    DataContext data = new DataContext(SPContext.Current.Web.Url);
    
    // Get the SharePoint list
    EntityList<Customer> Customers = data.GetList<Customer>("Customers");
    
    // Query for customers from London
    var londonCustomers = from customer in Customers
                          where customer.City == "London"
                          select customer;
    
    foreach (var londonCust in londonCustomers)
    {
        Console.Writeline("id = {0}, City = {1}", 
                          londonCust.CustomerId, 
                          londonCust.City);
    }
