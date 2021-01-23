    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,
                    Inherited = false)]
    public class ParameterValidationAttribute : ActionFilterAttribute
    {
      public override void OnActionExecuting(ActionExecutingContext filterContext)
      {
        var paramDescriptors = filterContext.ActionDescriptor.GetParameters();
        if (paramDescriptors == null || paramDescriptors.Length == 0)
          return;
        var parameters = filterContext.ActionParameters;
        object paramvalue = null;
        ModelStateDictionary modelState 
          = filterContext.Controller.ViewData.ModelState;
        ModelState paramState = null;
        ModelError modelError = null;
        foreach (var paramDescriptor in paramDescriptors)
        {
          paramState = modelState[paramDescriptor.ParameterName];
          //fetch the parameter value, if this fails we simply end up with null
          parameters.TryGetValue(paramDescriptor.ParameterName, out paramvalue);
          foreach (var validator in paramDescriptor.GetCustomAttributes
                    (typeof(ValidateParameterAttribute), false)
                    .Cast<ValidateParameterAttribute>().OrderBy(a => a.Order)
                  )
          {
            modelError = 
              validator.GetModelError(filterContext, paramDescriptor, paramvalue);
            if(modelError!=null)
            {
              //create model state for this parameter if not already present
              if (paramState == null)
                modelState[paramDescriptor.ParameterName] = 
                  paramState = new ModelState();
              paramState.Errors.Add(modelError);
              //break if no more validation should be performed
              if (validator.ContinueValidation == false)
                break;
            }
          }
        }
        base.OnActionExecuting(filterContext);
      }
    }
