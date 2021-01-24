    var context = new AppContext();
    GenericObject myObject = new GenericObject
    {
        Description = "some description"
    };
    UserObject user = new UserObject
    {
        Name = "user"
    };
    context.UserObjects.Add(user);
    context.GenericObjects.Add(myObject);
    context.SaveChanges();
