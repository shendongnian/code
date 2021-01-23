    public abstract class ContentController<T> : Controller 
    {
        protected virtual ActionResult Index()
        {
            return View();
        }
        internal ActionResult Index(T item)
        {
            return View(item);
        }
    }
