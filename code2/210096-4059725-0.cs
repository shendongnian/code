    public abstract class RESTController<T> : Controller
    {      
        public abstract JsonResult List();
        public abstract JsonResult Get(Guid id);
        public abstract JsonResult Create(T obj);
        public abstract JsonResult Update(T obj);
        public abstract JsonResult Delete(Guid Id);
    }
