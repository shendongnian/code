        using (NorthwindEntities ent = new NorthwindEntities())
        {
           var UsersList = ent.User.Include("Orders")
                    .Include("OrderDetails")
                    .Include("OrderDetails.Products");
           if (LastName != null)
              UserList = UserList.Where(o => o.LastName == LastName || o.LastName.contains(LastName));
           if (FirstName != null)
              UserList = UserList.Where(o => o.firstName== firstName||o.firstName.Contains(firstName);
           // etc
       }
