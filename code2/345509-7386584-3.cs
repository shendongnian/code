    var data = context.Users
                      .Where(...)
                      .Select(u => new UserLimitedView
                          {
                              Id = u.Id,
                              FirstName = u.FirstName,
                              LastName = u.LastName
                          });
    var fullData = context.Users.Where(...);
