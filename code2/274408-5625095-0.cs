    public interface IFilteredModelBinder : IModelBinder
    	{
    		bool IsMatch(Type modelType);
    	}
	public class SmartModelBinder : DefaultModelBinder
	{
		private readonly IFilteredModelBinder[] _filteredModelBinders;
		public SmartModelBinder(IFilteredModelBinder[] filteredModelBinders)
		{
			_filteredModelBinders = filteredModelBinders;
		}
		public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			foreach (var filteredModelBinder in _filteredModelBinders)
			{
				if (filteredModelBinder.IsMatch(bindingContext.ModelType))
				{
					return filteredModelBinder.BindModel(controllerContext, bindingContext);
				}
			}
			return base.BindModel(controllerContext, bindingContext);
		}
	}
	public class NewtonsoftJsonModelBinder : IFilteredModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			if (!controllerContext.HttpContext.Request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
			{
				// not JSON request
				return null;
			}
			var request = controllerContext.HttpContext.Request;
			request.InputStream.Position = 0;
			var incomingData = new StreamReader(request.InputStream).ReadToEnd();
			if (String.IsNullOrEmpty(incomingData))
			{
				// no JSON data
				return null;
			}
			object ret = JsonConvert.DeserializeObject(incomingData, bindingContext.ModelType);	
			return ret;
		}
		public bool IsMatch(Type modelType)
		{
			var ret = (typeof(JsonModel).IsAssignableFrom(modelType));
			return ret;
		}
	}
