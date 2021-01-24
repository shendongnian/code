    var query = from user in context.Users.Where(x => (conditions.Keyword == null || x.UserName.Contains(conditions.Keyword)))
                            join userRole in userRoleView
                            on user.Id equals userRole.UserId into gj
                            from p in gj.DefaultIfEmpty()
                            select new
                            {
                                user.Id,
                                user.UserName,
                                RoleName = p.Rolename,
                                user.CreatedUtc,
                                user.ModifiedUtc,
                            };
