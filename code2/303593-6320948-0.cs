    public class SearchModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName + ".Value");
            if (value != null)
            {
                return new Search
                {
                    Value = value.AttemptedValue
                };
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
