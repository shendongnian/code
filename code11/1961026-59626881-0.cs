 // Normally your controller will be accessible by only Authenticated users.
 [Authorize]
 public class HomeController : Controller
 {
        
        //In here you want your action to be accessible by everyone.
        //So you have to give another attribute in here, only for this action.
        //And continue to tag your other actions simply like this.
        [Authorize(Roles = "Admin, Manager, Writer")]
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
        
        //You dont have to add an extra attribute here, because anyway your controller
        //is only accessible to admin.
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
