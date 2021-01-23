    var result1 = (from a in users
                    b in roles
               where (a.RoleCollection.Any(x => x.RoleId = b.RoleId))
               select new 
               {
                  UserName = a.UserName,
                  RoleNames = b.RoleName)                 
               });
 
    var result2 = (from a in result1.ToList()
               group a by a.UserName into userGroup
               select new 
               {
                 UserName = userGroup.FirstOrDefault().UserName,
                 RoleNames = String.Join(", ", (userGroup.Select(x => x.RoleNames)).ToArray())
               });
