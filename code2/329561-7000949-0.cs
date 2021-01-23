    using (var context = new MyContext())
    {
        var myHugeBusinessObject = CreateItSomeHow();
        context.HugeBusinessObjects.Add(myHugeBusinessObject);
        context.SaveChanges();
    }
