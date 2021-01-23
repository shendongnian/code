    public class DateTimeModelBinder : IModelBinder
    {
    	public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    	{
    		var date = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).AttemptedValue;
    
    		if (String.IsNullOrEmpty(date))
    			return null;
    
    		bindingContext.ModelState.SetModelValue(bindingContext.ModelName, bindingContext.ValueProvider.GetValue(bindingContext.ModelName));
    		try
    		{
    			return DateTime.Parse(date);
    		}
    		catch (Exception)
    		{
    			bindingContext.ModelState.AddModelError(bindingContext.ModelName, String.Format("\"{0}\" is invalid.", bindingContext.ModelName));
    			return null;
    		}
    	}
    }
