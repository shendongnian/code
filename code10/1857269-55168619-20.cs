    using (var ctx = new TestContext())
    {
        GenericObject myObject = new GenericObject();
        myObject.description = "testobjectdescription";
        User usr = new User() { Name = "Test"};
        ctx.Users.Add(usr);
        //myObject.UserWhoGeneratedThisObject = usr;
        ctx.GenericObjects.Add(myObject);
        ctx.SaveChanges();
    }
