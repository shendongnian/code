    var myEntity = new SomeEntity(){
           Name="Test",
           CreatedDate = DateTime.UtcNow,
           MyChildObject = new ChildObject(){
               Name="Something else",
               CreatedDate = DateTime.UtcNow
        }
        
        dbContext.MyEntities.Add(myEntity);
        dbContext.SaveChanges();        
        Console.WriteLine(myEntity.MyChildObject.Id);
