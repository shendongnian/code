        //if your question is how to display(Print!) a view for above query then in ActionResult Index()
        //1] As as best practise always Create a ViewModel - UserViewModel
          public class UserviewModel
          {
            public string Username {get;set;}
            public string Address {get;set;}
          }
        //2] Assign db.user values to UserviewModel or you can use Automapper
        //and 3] then return this viewmodel to view  
        return View(UserviewModel);
