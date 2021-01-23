    public class Repository : IDisposable
    {
        DevEntities db = new DevEntities();
    
        public Customer GetCustomerByID(int id)
        {
            var customers = db.Customers.FirstOrDefault(c => c.CustomerId == id);
    
            return customers;
        }
    
        public Customer GetCustomerByPasswordUsername(string email, string password)
        {
            var customers = db.Customers.FirstOrDefault(c => c.Email == email && c.Password == password);
    
            return customers;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
