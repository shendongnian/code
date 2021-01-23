    public override object BindModel(ControllerContext controllerContext,
        ModelBindingContext bindingContext)
            {
                var address = base.BindModel(controllerContext, bindingContext) as Address;
                if (bindingContext.ModelName.EndsWith("BillingAddress"))
                {
                    foreach (PropertyInfo p in address.GetType().GetProperties())
                    {
                    Attribute a = Attribute.GetCustomAttribute(p, typeof(RequiredAttribute));
                    if (a != null 
                        && propertyInfo.GetValue(address, null) == null 
                        && bindingContext.ModelState[bindingContext.ModelName 
                           + "." + p.Name].Errors.Count == 1)
                    {
                        bindingContext.ModelState[bindingContext.ModelName + "." + p.Name].Errors.Clear();
                    }
                }
                return address;
            }
