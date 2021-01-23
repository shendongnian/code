    public class TimeSpanModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName + ".TotalMinutes");
            int totalMinutes;
            if (value != null && int.TryParse(value.AttemptedValue, out totalMinutes))
            {
                return TimeSpan.FromMinutes(totalMinutes);
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
