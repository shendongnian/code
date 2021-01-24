                List<string> roleNames = _userManager.GetRolesAsync(user).Result.ToList();
                string userRoles = "";
                foreach(string rname in roleNames)
                {
                    if (userRoles.Trim().Length == 0)
                        userRoles = rname;
                    else
                        userRoles = userRoles + "," + rname;
                }
                var claims = new List<Claim>
                {
                    new Claim("UserId", user.Id),
                    new Claim("UserName", user.UserName),
                    new Claim("UserRoles", userRoles),
                    new Claim(ClaimTypes.Role,roleNames.FirstOrDefault()),
                    new Claim(ClaimTypes.Sid, user.Id)
                };           
    
