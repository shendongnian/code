    using System.Web.Mvc;
    
    namespace SearchAndSubmit.Controllers
    {
        public class UserViewModel
        {
            public int? Id { get; set; }
            public string Name { get; set; }
        }
    
        public class HomeController : Controller
        {
            [HttpGet]
            public ActionResult Edit(int? SearchId)
            {
                var viewModel = new UserViewModel();
              
    
                if (SearchId != null)
                {
                    viewModel.Id = SearchId;
                   //logic to search for user and create viewmodel goes here              
                }
    
                return View(viewModel);
            }   
    
            [ValidateAntiForgeryToken]
            public ActionResult Edit(UserViewModel user_Pers)
            {
                //validation and create update logic goes here
                return RedirectToAction("Index");    
            }    
        }
    }
