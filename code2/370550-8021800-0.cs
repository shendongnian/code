    public class BaseController<T> : Controller where T :IPageModel,new()
    {
        public virtual ActionResult Index()
        {
            IPageModel model = new T();
            return View(model);
        }
    }
