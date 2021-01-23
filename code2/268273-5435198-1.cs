    public class Reports : Controller
    {
        public ActionResult Show(int id)
        {    
            //Create ViewModel from Model to send to report page:
            return View("Report", viewModel);
        }
    }
