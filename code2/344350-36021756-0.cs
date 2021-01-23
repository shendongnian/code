      var roles = (from r in roleNames
                                        join rm in DataContext.FMC_RoleMaps on r equals rm.RoleName_old
                                        select new
                                        {
                                            dnnUser.UserID,
                                            rm.RoleID
                                        }
                                               );
                           foreach (var userRole in roles)
                           {
                               var newrole = new UserRole()
                                                 {
                                                     RoleID = userRole.RoleID,
                                                     UserID = userRole.UserID
                                                 };
                               DataContext.UserRoles.InsertOnSubmit(newrole);
                           }
