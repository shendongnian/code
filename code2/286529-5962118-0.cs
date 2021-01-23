    var context = new MyDataContext();
    var user = context.User.GetByKey("username");
    // change field values
    ...
    user.AnyUserField = "123";
    ...
    context.AcceptAllChanges();
    context.ObjectStateManager.ChangeObjectState(user, EntityState.Added); // or use EntityState.Modified if it already exist anywhere
    context.SaveChanges();
