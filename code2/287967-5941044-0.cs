    var UsersList = ent.User.Include("Orders")
                   .Include("OrderDetails")
                   .Include("OrderDetails.Products");
    
    if (!string.IsNullOrEmpty(firstName))
       UsersList = UsersList.Where( o => o.firstName.Contains(firstName));
    
    if (!string.IsNullOrEmpty(LastName))
       UsersList = UsersList.Where( o => o.LastName.Contains(LastName));
