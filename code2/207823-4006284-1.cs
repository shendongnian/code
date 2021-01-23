    public class CalculatorController : Controller {
        [HttpGet]
        public ActionResult Sum() {
            CalculatorModel model = new CalculatorModel();
            //Return the result
            return View(model);
        }
        [HttpPost]
        public ActionResult Sum( CalculatorModel model ) {
            model.Result = model.FirstOperand + model.SecondOperand;
            //Return the result
            return View(model);
        }
    }
