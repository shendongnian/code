     [Authorize]
     public class HomeController : Controller
     {
        [AllowAnonymous]
        public async Task<IActionResult> ForEveryone()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> ForAdminAndManager()
        {
            return View();
        }
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> ForWriterOnly()
        {
            return View();
        }
        [Authorize (Roles = "Admin")]
        public async Task<IActionResult> ForAdminOnly()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> ForAdminAndManager1()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> ForAdminAndManager2()
        {
            return View();
        }
