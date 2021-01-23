    public class CultureAwareModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            /* code that determines the culture */
            var cultureInfo = CultureHelper.GetCulture(controllerContext.HttpContext);
            //set current thread culture
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            return base.BindModel(controllerContext, bindingContext);
        }
    }
