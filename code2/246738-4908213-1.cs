    public class SomeClass
    {
        // Get the ICustomerQuery through DI
        public SomeClass(ICustomerQuery customerQuery)
        {
            _customerQuery = customerQuery;
        }
    
        public void SomeServiceMethod()
        {
            _customerQuery()
                .WhereLivingOutSideUnitedStates()
                .WhereAgeGreaterThan(55)
                .Select();
        }
    }
