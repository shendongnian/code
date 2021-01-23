    using System.Linq;
    
    namespace Linq_customer
    {
        public partial class Customer
        {
            public static Customer GetCustomerByID(int customerID, CustomerDataContext dc)
            {
    
                return (from s0 in dc.Customers
                       where s0.customerID== customerID
                       select s0).firstOrDefault();
            }
        }
    }
