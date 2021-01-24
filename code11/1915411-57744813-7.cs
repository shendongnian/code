    public class HomeController : Controller {        
        public async Task<ActionResult> Index() {
            var webService = new WebService();
            var model = await webService.GetTeams();
            var teams = model.teams;
            //...
            return View(teams);
        }
    }
