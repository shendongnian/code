    var q = from c in Customers select c;
    if(!String.IsNullOrEmpty(param.Name))
        q.Where(c => c.Name.Contains(param.Name));
    
    if(param.CustID.HasValue)
        q.Where(c => c.ID == param.CustID);
    if(!String.IsNullOrEmpty(param.CustAddr))
        q.Where(c => c.Addr.Contains(param.CustAddr));
    //use your results!
