    public class MyDefaultModelBinder : DefaultModelBinder
    {
        protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor, object value)
        {
            //special case for DateTime
            if(propertyDescriptor.PropertyType == typeof(DateTime))
            {
                if (propertyDescriptor.IsReadOnly)
                {
                    return;
                }
                try
                {
                    if(value != null)
                    {
                        DateTime dt = (DateTime)value;
                        propertyDescriptor.SetValue(bindingContext.Model, dt.ToUniversalTime());
                    }
                }
                catch (Exception ex)
                {
                    string modelStateKey = CreateSubPropertyName(bindingContext.ModelName, propertyDescriptor.Name);
                    bindingContext.ModelState.AddModelError(modelStateKey, ex);
                }
            }
            else
            {
                //handles all other types
                base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);
            }
        }
    }
 
