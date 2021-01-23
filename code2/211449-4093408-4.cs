    public class Customer : BaseEntityModel<CustomerEntity>
    {
        public void Method()
        {
            // Entity is of type Customer entity
            Entity.CustomerName = "Bob";
            base.Save();
        }
    
    }
