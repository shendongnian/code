    var context = new AppContext();
    GenericObject myObject = new GenericObject
    {
        Description = "some description"
    };
    UserObject user = new UserObject
    {
        Name = "user"
    };
    UserObject user2 = new UserObject
    {
        Name = "user"
    };
    context.UserObjects.Add(user);
    context.UserObjects.Add(user2);
    context.GenericObjects.Add(myObject);
    context.SaveChanges();
