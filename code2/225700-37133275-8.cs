    public class SavingsAccountCustomerDataAccess : BaseDataAccess
    {
        public SavingsAccountCustomerDataAccess(IDatabaseFactory factory)
        {
            this.Database = factory.GetSavingsAccountCustomerDatabase();
        }
    }
