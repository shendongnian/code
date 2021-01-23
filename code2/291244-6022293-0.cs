    public class Customer : MembershipUser
    {
        #region Properties
        private MembershipUser _user;
        ....
        #region Load
        public static Customer Load(IDataReader iDataReader) 
        {
            Customer oCustomer = new Customer();
            ...
            if(!string.IsNullOrEmpty(oCustomer.UserIdAspNet))
            {
                oCustomer._user = Membership.GetUser(Guid.Parse(oCustomer.UserIdAspNet));
            }
            return oCustomer;
        }
    }
