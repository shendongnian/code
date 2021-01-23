    public class IntModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value != null)
            {
                int temp;
                if (!int.TryParse(value.AttemptedValue, out temp))
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, string.Format("The value '{0}' is not valid for {1}.", value.AttemptedValue, bindingContext.ModelName));
                    bindingContext.ModelState.SetModelValue(bindingContext.ModelName, value);
                }
                return temp;
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
