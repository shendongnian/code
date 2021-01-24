    public class HomeController : Controller {        
        public async Task<ActionResult> Index() {
            // Ideally web service should be injected but that topic
            // is outside of the scope of the question at the moment.
            var webService = new WebService();
            var model = await webService.GetTeamsAsync();
            var teams = model.teams;
            //...
            return View(teams);
        }
    }
