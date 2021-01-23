    public class TabsActionFilter : ActionFilterAttribute 
    { 
        private readonly ICustomerGetter _getter;
        public TabsActionFilter(ICustomerGetter getter)
        { _getter = getter; }
        public override void OnActionExecuted(ActionExecutedContext filterContext) 
        { 
            Customer customer = _getter.GetCustomer(filterContext); 
     
            ...
        } 
    } 
    public interface ICustomerGetter
    { 
         Customer GetCustomer(ActionExecutedContext filterContext);
    }
