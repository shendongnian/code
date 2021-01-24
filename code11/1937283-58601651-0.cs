    public class HomeController : Controller
        {
               public ActionResult MyDropDownView()
            {
                // shows your form when you load the page
                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem { Text = "Status & Test", Value = "0" });
                li.Add(new SelectListItem { Text = "Status", Value = "1" });
                li.Add(new SelectListItem { Text = "Test", Value = "2" });
                li.Add(new SelectListItem { Text = "No Filter", Value = "3" });
                ViewData["pgFilter"] = li;
                return View();
            }
    
            [HttpPost]
            public ActionResult MyResultAction(string selectedFilterId)
            {
                //do what ever you want
                return View();
            }
        }
