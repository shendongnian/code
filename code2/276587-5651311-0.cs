    public class EmailModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var email = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (email != null)
            {
                return new EMailAddress(email.AttemptedValue);
            }
            return new EMailAddress(string.Empty);
        }
    }
