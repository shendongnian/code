    public class MyPropertyBinder : DefaultModelBinder
    {
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor)
        {
            base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
            for (int i = 0; i < propertyDescriptor.Attributes.Count; i++)
            {
                if (propertyDescriptor.Attributes[i].GetType() == typeof(BindingNameAttribute))
                {                    
                    // set property value.
                    propertyDescriptor.SetValue(bindingContext.Model, controllerContext.HttpContext.Request.Form[(propertyDescriptor.Attributes[i] as BindingNameAttribute).Name]);
                    break;
                }
            }
        }
    }
