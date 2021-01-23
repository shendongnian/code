    var user = new User(); 
    user.Id = GetUserIDfromService(); 
    context.Users.Add(user); 
    foreach(var address in GetAddressesFromService(user.Id))
    {
      context.Addresses.Attach(address);
      // Let say that new address always have 0 Id      
      context.Entry(address).State = address.Id == 0 ? EntityState.Added : EntityState.Modified;      
      user.Addresses.Add(address); 
    } 
    context.SaveChanges();
