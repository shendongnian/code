    using (var context = new MyContext())
    {
      var myObject = new MyObject { ID = 3 };
      context.MyObjectSet.Attach(myObject);
      context.MyObjectSet.DeleteObject(myObject);
      context.SaveChanges();
    }
