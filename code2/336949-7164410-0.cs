    var context = new DbContext();
    var result = context.Securables
                        .Where(s => s.Roles
                                     .Any(r => r.Users
                                                .Any(u => u.UserId = userId)))
                        .Distinct();
