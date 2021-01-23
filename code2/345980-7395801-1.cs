    public class DiagControllerActionInvoker : ControllerActionInvoker
    {
        protected override FilterInfo GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            FilterInfo baseFilters = base.GetFilters(controllerContext, actionDescriptor);
	
            //Add new filters
            //e.g. baseFilters.ActionFilters.Insert(0, actionFilter);
            return baseFilters;
        }
     }
