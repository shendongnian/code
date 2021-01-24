         public class CustomerServices {
     
            public static CustomerDatabase CustomerDatabase
            {
                    get
                    {  
                        return value ??  new CustomerDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                    }
            }
        
            public async Task<List<Customer>> GetCustomers()
            {
                return await CustomerDatabase.GetCustomerAsync();
            }
        
         }
