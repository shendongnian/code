    public class TreasuryIndexRateDecimalBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var providerResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (providerResult != null)
            {
                decimal value;
                if (!decimal.TryParse(providerResult.AttemptedValue, NumberStyles.Float, CultureInfo.CurrentCulture, out value))
                {
                    // TODO: Decide whether to show an error
                    // bindingContext.ModelState.AddModelError(bindingContext.ModelName, "error message");
                    return 0m;
                }
                return Math.Round(value, 6);
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
