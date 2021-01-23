    public class MyModelCookiesModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var cookie = controllerContext.HttpContext.Request.Cookies["someCookie"];
            MyModel myModel = GetModelFromCookie(cookie);
            return myModel;
        }
    
        private MyModel GetModelFromCookie(HttpCookie cookie)
        {
            // TODO:
            throw new NotImplementedException();
        }
    }
