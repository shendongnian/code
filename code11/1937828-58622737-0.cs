     foreach (var user in adUsers)
    {
        try{
            if (!users.Keys.Contains(user.Mail) && user.Mail.EndsWith("@warburgpincus.com"))
                users.Add(user.Mail, new User
                {
                    FirstName = user.GivenName,
                    LastName = user.Surname,
                    Username = user.UserPrincipalName,
                    Email = user.Mail,
                    IsActive = true,
                    Role = adminMembers.Any() && adminMembers.Where(x => x.Mail == user.Mail).Any() ? RoleTypes.AdminUser :
                    readOnlyMembers.Any() && readOnlyMembers.Where(x => x.Mail == user.Mail).Any() ? RoleTypes.ReadOnlyUser : RoleTypes.User
                });
    
                else if (string.IsNullOrEmpty(user.Mail))        
                {
    
                  throw new ApplicationException($"User {user.GivenName + user.Surname} cannot sync to Quill due to missing email address");
                 }
         }
         catch(Exception ex){
            //log exception here.
         }
    
       }
     return users;
