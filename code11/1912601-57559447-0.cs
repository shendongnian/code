    using (var db = new MyDatabase())
    {
       var things = new ThingRepository(db);
       var anotherThings = new AnotherThingRepository(db);
    
       . . .
    
       db.SaveChanges();
    }
