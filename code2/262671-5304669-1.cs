    using(var context = new YourDataContext())
    {
       //use context for CRUD operation
       Entity1 entity1 = context.Entities1.Where(e1 => e1.Id == 1);
       entity1.Prop1 = "New Value";  
         
       context.Entities2.Add(entity2)
 
       context.SaveChanges();
    }
