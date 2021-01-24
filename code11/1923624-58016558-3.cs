    public class CustomerViewModel {
    
        public CustomerViewModel(ICustomerService service) {
            //...
        }
        //...
        public Task<Customer> GetCustomerInfo(string id, string name) {
            //...calls ICustomerService.GetCustomerDetails(id, name);
        }
    }
