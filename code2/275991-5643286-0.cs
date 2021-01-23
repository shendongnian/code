    public class UserCultureDateTimeModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            object value = controllerContext.HttpContext.Request[bindingContext.ModelName];
            if (value == null)
                return null;
            
            // Request.UserLanguages could have multiple values or even no value.
            string culture = controllerContext.HttpContext.Request.UserLanguages.FirstOrDefault();
            return Convert.ChangeType(value, typeof(DateTime), CultureInfo.GetCultureInfo(culture));
        }
    }
...
    ModelBinders.Binders.Add(typeof(DateTime?), new UserCultureDateTimeModelBinder());
