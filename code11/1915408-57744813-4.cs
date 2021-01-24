    public class HomeController : Controller {    
        APIController webService = new APIController();
        public async Task<ActionResult> Index() {    
            var model = await webService.GetTeams();
            var teams = model.teams;
            return View();
        }
    }
