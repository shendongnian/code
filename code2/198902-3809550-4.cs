    public class HomeController {
        public ActionResult Index(int id) {
            //check database for id
            if(id_exists) {
                return new RedirectResult("whereever you want to redirect", true);
            } else {
                return new HttpNotFoundResult();
            }
        }
    }
