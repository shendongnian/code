    public class BaseControllr : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Get the id from route
            var id = int.TryParse(ValueProvider.GetValue("id")?.AttemptedValue, out var temp)
                ? temp : default(int?);
            var model = new LayoutViewModel();
            //Your logic to initialize the model, for example
            model.Id = id;
            if (model.Id == null)
                model.Color = "FF0000";
             else if (model.Id%2==0)
                model.Color = "00FF00";
            else
                model.Color = "0000FF";
            //Set ViewBag
            ViewBag.MainLayoutViewModel = model;
            base.OnActionExecuting(filterContext);
        }
    }
