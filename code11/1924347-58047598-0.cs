    public class ProduceResponseTypeModelProvider : IApplicationModelProvider
    {
        public int Order => 3;
    
        public void OnProvidersExecuted(ApplicationModelProviderContext context)
        {
        }
    
        public void OnProvidersExecuting(ApplicationModelProviderContext context)
        {
            foreach (ControllerModel controller in context.Result.Controllers)
            {
                foreach (ActionModel action in controller.Actions)
                {
                    // I assume that all you actions type are Task<ActionResult<ReturnType>>
    
                    Type returnType = action.ActionMethod.ReturnType.GenericTypeArguments[0].GetGenericArguments()[0];
    
                    action.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status510NotExtended));
                    action.Filters.Add(new ProducesResponseTypeAttribute(returnType, StatusCodes.Status200OK));
                    action.Filters.Add(new ProducesResponseTypeAttribute(returnType, StatusCodes.Status500InternalServerError));
                }
            }
        }
    }
