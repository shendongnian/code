    public class NumbersController : Controller
    {
        private INumbersBusinessLayer _numbersBusinessLayer;
        public NumbersController(INumbersBusinessLayer numbersBusinessLayer)
        {
            _numbersBusinessLayer = numbersBusinessLayer;
        }
        public ActionResult Index()
        {
           var  modelList = _numbersBusinessLayer.AllNumbers.ToList();
            return View(modelList);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _numbersBusinessLayer.AllNumbers.Single(n => n.ID == id);
            return View(model);
        }
    }
