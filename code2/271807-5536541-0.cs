    public class TimeOfDayModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            try
            {
                // Let the TimeOfDay struct take care of the conversion from string.
                return new TimeOfDay(result.AttemptedValue, result.Culture);
            }
            catch (ArgumentException)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Value is invalid. Examples of valid values: 6:30, 16:00");
                // This line is what makes the difference:
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, result);
                return bindingContext.Model;
            }
        }
    }
