    public class CustomerOrderBL
    {
        private Database session;
    
        public CustomerOrderBL(Database session)
        {
            this.session = session;
        }
    
        public CustomerOrder GetByCoNum(string coNum)
        {
            return session.FirstOrDefault<CustomerOrder>(x => x.CustomerNumber == coNum);
        }
    }
