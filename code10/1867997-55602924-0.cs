    var userInfo = context.User.Select(u => new UserModel
     {
       UserRoles =Enum.GetName(typeof(UserRole), u.Roles) , 
       UserNames = u.Names,
       UserAddress = u.Address
     }).ToList();
