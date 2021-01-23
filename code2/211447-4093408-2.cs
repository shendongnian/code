    public class Company : BaseEntityModel<CompanyEntity>
    {
         public void Method()
          {
            // Entity is of type Customer entity
            Entity.CompanyName = "My Company";
            base.Save();
         }
 
    }
