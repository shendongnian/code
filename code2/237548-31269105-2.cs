    public class NullableGuidBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(Guid?))
            {
                var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                string input = valueResult.AttemptedValue;
                if (string.IsNullOrEmpty(input) || input == "0")
                {
                    // return null, even if input = 0
                    // however, that is dropdowns' "guid.empty")
                    // base.BindModel(...) would fail converting string to guid, 
                    // Guid.Parse and Guid.TryParse would fail since they expect 000-... format
                    // add the property to modelstate dictionary
                    var modelState = new ModelState { Value = valueResult };
                    bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
                    return Guid.Empty;
                }
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
