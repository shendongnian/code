    using Microsoft.Practices.Unity;
    
    public class OrderController
    {
        IOrderRepository _orderRepository;
    
        [InjectionConstructor]
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
    
        public List<string> GetFilters()
        {
            // Return list of filters.
        }
    
        public List<Order> GetFilteredOrders(string filter)
        {
            switch (filter)
            {
                case "Newest":
                    return // Get orders sorted by newest first.
                case "Oldest":
                    return // Get orders sorted by oldest first.
                default:
                    return // etc etc etc
            }
        }
    }
    
    
    /// 
    /// From Global.asax.cs
    
    using Microsoft.Practices.Unity;
    
    private void ConfigureUnity()
    {        
    	// Create UnityContainer           
    	IUnityContainer container = new UnityContainer()
    	.RegisterInstance(new OrderController())
    	.RegisterType<IOrderRepository, OrderRepository>();
    
    	// Set container for use in Web Forms
    	WebUnityContainer.Container = container;
    }       
    
    ///
    /// Creating the OrderController from your Web UI
    
    public OrderController CreateOrderController()
    {
    	return WebUnityContainer.Container.Resolve<OrderController>();
    }
    
    ///
    /// Shared static class for the Unity container
    
    using Microsoft.Practices.Unity;
    
    namespace MyCompany.MyApplication.Web
    {
        public static class WebUnityContainer
        {
            public static IUnityContainer Container { get; set; }
        }
    }
    
