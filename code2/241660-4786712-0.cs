    public class BBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value != null)
            {
                if (value.AttemptedValue == "1")
                {
                    return true;
                }
                else if (value.AttemptedValue == "0")
                {
                    return false;
                }
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
