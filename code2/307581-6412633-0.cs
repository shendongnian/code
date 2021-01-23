    public class DateTimeModelBinder : IModelBinder
    {
    #region IModelBinder Members
    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
        if (controllerContext.HttpContext.Request.HttpMethod == "GET")
        {
            string theDate = controllerContext.HttpContext.Request.Form[bindingContext.ModelName];
            DateTime dt = new DateTime();
            bool success = DateTime.TryParse(theDate, System.Globalization.CultureInfo.CurrentUICulture, System.Globalization.DateTimeStyles.None, out dt);
            if (success)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        DefaultModelBinder binder = new DefaultModelBinder();
        return binder.BindModel(controllerContext, bindingContext);
    }
    #endregion
    }
