    public class ProcessorOne
    {
       private readonly DatabaseIntegration databaseIntegration;
       public ProcessorOne(DatabaseIntegration databaseIntegration)
       {
           this.databaseIntegration = databaseIntegration;
       }
       public void Process()
       {                                  
          Entity entity = new Entity(){entityName = "NameOne"}
          this.dataBaseIntegration.Save(entity);
       }
     }
    public class ProcessorTwo
    {
       private readonly DatabaseIntegration dataBaseIntegration;
       public ProcessorTwo(DatabaseIntegration dataBaseIntegration)
       {
           this.dataBaseIntegration = dataBaseIntegration;
       }
       public void Process()
       {            
          Entity entity = new Entity(){entityName = "NameTwo"}
          this.dataBaseIntegration.Save(entity);
       }
    }
    public class DatabaseIntegration 
    {
       public void Save(Entity entity)
       {            
         using (DbContext context = new DbContext(sqlConnection))
         {
             context.Entity.Add(entity);
             context.SaveChanges();                 
         }
       }
    }
