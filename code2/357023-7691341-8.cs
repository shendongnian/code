    public class UserController : Controller
    {
       public ActionResult Create()
       {
          List<DivisionModel> divisions = new List<DivisionModel>();
          divisions.Add(new DivisionModel() { DivisionId = 1, DivisionName = "Division1" });
          divisions.Add(new DivisionModel() { DivisionId = 2, DivisionName = "Division2" });
    
          UserModel user = new UserModel() { Username = "testUser", EmailAddress = "testAddress@test.com" };
    
          return View(new UserViewModel() { User = user, Divisions = divisions });
       }
    }
