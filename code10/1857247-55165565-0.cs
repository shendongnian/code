    using (var ctx = new Tests6Context()) {
        GenericObject myObject = new GenericObject();
        myObject.description = "testobjectdescription";
        User usr = new User() { Name = "Test" };
        ctx.Users.Add(usr);
        //myObject.UserWhoGeneratedThisObject = usr;
        ctx.GenericObjects.Add(myObject);
        myObject = new GenericObject();
        myObject.description = "testobjectdescription 2";
        usr = new User() { Name = "Test 2" };
        ctx.Users.Add(usr);
        //myObject.UserWhoGeneratedThisObject = usr;
        ctx.GenericObjects.Add(myObject);
        ctx.SaveChanges();
    }
