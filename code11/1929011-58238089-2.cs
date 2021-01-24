    public class DictionaryBinder : IModelBinder
    {
    	public async Task BindModelAsync(ModelBindingContext bindingContext)
    	{
    		if (bindingContext == null)
    		{
    			throw new ArgumentNullException(nameof(bindingContext));
    		}
    
    		if (bindingContext.HttpContext.Request.HasFormContentType)
    		{
    			var form = bindingContext.HttpContext.Request.Form;
    			var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(form[bindingContext.FieldName].ToString());
    			bindingContext.Result = ModelBindingResult.Success(data);
    		}
    	}
    }
