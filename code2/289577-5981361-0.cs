    public class CustomerModel
    {
        //properties
    }
    
    public class OrderModel
    {
        //properties
    }
    
    public class CustomerVM
    {
        public CustomerModel customer { get; set; }
        public IEnumerable<OrderModel> orders { get; set; }
    }
    
    //and in your controller
    
    public class CustomerController : Controller
    {
        public ActionResult Index(int id)
        {
            CustomerVM vm = new CustomerVM();
            vm.customer = CustomerRepository.GetCustomer(id);
            vm.orders = OrdersRepository.GetOrdersForCustomer(id);
            return View(vm);
            
        }
    }
