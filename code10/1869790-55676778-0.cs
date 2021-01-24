          if (users != null && users.Length > 0 )
            {
                foreach (var item in users)
                {
                    var userRoles = await UserManager.GetRolesAsync(item);
                    if (userRoles.Contains("Foreman"))
                    {
                        CW.AddRange(db.CrewMemberForeman.Where(x => x.AssignedForemanId == item).Select(x => x.CrewMember).OrderBy(x => x.FirstName).ToList());
                    }
                }
            }
