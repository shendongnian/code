        public class HomeController : Controller {
            proNameEntities DB = new proNameEntities();   //initalise db entities here        
            public ActionResult Index(){
                ViewModel vm = new ViewModel();
                vm.Users = this.DB.Users
                return View(vm); // pass the viewmodel object to the view
            }
        }
