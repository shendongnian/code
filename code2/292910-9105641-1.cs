    public class JsonModelBinder : DefaultModelBinder {     
      public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder)  
      {
            var propertyType = propertyDescriptor.PropertyType;
            if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                var provider = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                if (provider != null 
                    && provider.RawValue != null 
                    && Type.GetTypeCode(provider.RawValue.GetType()) == TypeCode.Int32) 
                {
                    var value = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize(provider.AttemptedValue, bindingContext.ModelMetadata.ModelType);
                    return value;
                }
            } 
                
            return base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
      }
    }
