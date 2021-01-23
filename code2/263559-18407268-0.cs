     var usernames = Roles.GetUsersInRole("Administrator");
                
                var adminUsers = db.UserProfiles
                     .Where(x => !usernames.Contains(x.UserName)).ToList();
                return View(adminUsers);
