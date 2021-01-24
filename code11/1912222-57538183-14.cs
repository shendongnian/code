    public class DoubleModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult == null)
            {
                return base.BindModel(controllerContext, bindingContext);
            }
            return double.Parse(valueProviderResult.AttemptedValue, System.Globalization.CultureInfo.InvariantCulture);           
        }
    }
