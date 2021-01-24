    var myEntity = new SomeEntity(){
       Name="Test",
       CreatedDate = DateTime.UtcNow
    }
    
    dbContext.MyEntities.Add(myEntity);
    dbContext.SaveChanges();
    
    Console.WriteLine(myEntity.Id);
