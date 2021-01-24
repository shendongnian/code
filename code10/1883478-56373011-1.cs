    public class Customer
    {
        private readonly IMyService _service;
        public Customer(IMyService service)
        {
            _service = service;
        }
        public string CustomerNameById(int id)
        {
            var result = _service.ReadCustomerNameById(id);
            //validate, massage and do whatever you need to do to your response
            return result;
        }
    }
