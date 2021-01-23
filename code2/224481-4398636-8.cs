    public abstract class ContentController<T> : Controller 
    {
        public virtual ActionResult Index()
        {
            return View();
        }
        internal ActionResult Index(T item)
        {
            return View(item);
        }
    }
