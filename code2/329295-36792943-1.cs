    public class SchoolDBInitializer :  CreateDatabaseIfNotExists<SchoolDBContext>{ 
       protected override void Seed(SchoolDBContext context)
        {   
           base.Seed(context);  
        }
    }
