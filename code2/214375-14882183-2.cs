    public class MyActionFilter: Attribute, IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext context)
            {
            }
    
            public void OnActionExecuting(ActionExecutingContext context)
            {
                var myController= context.Controller as MyController;
    
                if (myController!= null)
                {
                    myController.Layout = new MainLayoutViewModel
                    {
                        
                    };
    
                    myController.ViewBag.MainLayoutViewModel= myController.Layout;
                }
            }
        }
