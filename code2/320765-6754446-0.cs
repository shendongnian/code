    public class Home: Controller{
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(MyModel model){
            // do something
        }
    }
