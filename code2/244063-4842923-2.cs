    public class MyBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value != null)
            {
                return value.AttemptedValue.Split(',');
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
    public class HomeController : Controller
    {
        public ActionResult Index(
            [ModelBinder(typeof(MyBinder))] IEnumerable<string> values
        )
        {
            return View();
        }
    }
