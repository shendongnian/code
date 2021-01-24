 // Normally your controller will be accessible by only Authenticated users.
 [Authorize]
 public class HomeController : Controller
 {
        
        //In here you want your action to be accessible by everyone.
        //So you dont have to give any attributes in here.
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
}
