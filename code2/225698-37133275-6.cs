    public class MortgageCustomerDataAccess : BaseDataAccess
    {
        public MortgageCustomerDataAccess(IDatabaseFactory factory)
        {
            this.Database = factory.GetMortgageCustomerDatabase();
        }
    }
