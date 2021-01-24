    ...
    dbContext.User.Add(user);
    dbContext.SaveChanges();
    _Users.Add(user);
    OnPropertyChanged(() => Users);
