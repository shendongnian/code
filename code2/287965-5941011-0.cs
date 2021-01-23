    var UsersList = ent.User.Include("Orders")
                            .Include("OrderDetails")
                            .Include("OrderDetails.Products");
    if(!string.IsNullOrEmpty(firstName));
       UsersList = UsersList.Where( o => o.firstName.Contains(firstName));
    if(!string.IsNullOrEmpty(lastName));
       UsersList = UsersList.Where( o => o.lastName.Contains(lastName))
