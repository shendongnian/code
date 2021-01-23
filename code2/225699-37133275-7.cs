    public class CurrentAccountCustomerDataAccess : BaseDataAccess
    {
        public CurrentAccountCustomerDataAccess(IDatabaseFactory factory)
        {
            this.Database = factory.GetCurrentAccountCustomerDatabase();
        }
    }
