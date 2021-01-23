        public class DelimitedArrayModelBinder : IModelBinder
    	{
    		public DelimitedArrayModelBinder()
    			: this(null)
    		{
    		}
    
    		public DelimitedArrayModelBinder(params string[] delimiters)
    		{
    			m_delimiters = delimiters != null && delimiters.Any()
    				? delimiters
    				: new[] { "," };
    		}
    
    		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    		{
    			// type must be an array
    			if (!bindingContext.ModelType.IsArray)
    				return null;
    
    			// array must have a type
    			Type elementType = bindingContext.ModelType.GetElementType();
    			if (elementType == null)
    				return null;
    
    			// value must exist
    			ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
    			if (valueProviderResult == null)
    				return null;
    
    			string strValue = valueProviderResult.AttemptedValue;
    			if (string.IsNullOrEmpty(strValue))
    				return null;
    
    			List<object> items = new List<object>();
    			foreach (string strItem in strValue.Split(m_delimiters, StringSplitOptions.RemoveEmptyEntries))
    			{
    				try
    				{
    					object item = Convert.ChangeType(strItem, elementType);
    					items.Add(item);
    				}
    				catch (Exception)
    				{
    				  // if we can't convert then ignore or log
    				}
    			}
    
    			// convert the list of items to the proper array type.
    			Array result = Array.CreateInstance(elementType, items.Count);
    			for (int i = 0; i < items.Count; i++)
    				result.SetValue(items[i], i);
    
    			return result;
    		}
    
    		private readonly string[] m_delimiters;
    	}
