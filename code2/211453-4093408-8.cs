    public class Company : BaseEntityModel<CompanyEntity>
    {
         public void Method()
          {
            // Entity is of type Company entity
            Entity.CompanyName = "My Company";
            base.Save(); // Save is declared in the base class for a generic type (in this case company)
         }
 
    }
