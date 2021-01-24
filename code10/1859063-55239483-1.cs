    public class Controller : ControllerBase
    {
        public dynamic ViewBag { get; }
        public virtual ViewResult View(object model) { }
        // more
    }
