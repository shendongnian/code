    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new TestViewModel
            {
                IgnoreProperty = "to be ignored",
                UpdateProperty = "to be updated",
                ComplexProperty = new ComplexType
                {
                    Code = 1,
                    Name = "5"  
                }
            };
            if (TryUpdateModel(model))
            {
                
            }
            return View();
        }
    }
