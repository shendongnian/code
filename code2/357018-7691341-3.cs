    public class UserController : Controller
    {
       public ActionResult Index()
       {
          List<DivisionModel> divisions = new List<DivisionModel>();
          divisions.Add(new DivisionModel() { DivisionId = 1, DivisionName = "Division1" });
          divisions.Add(new DivisionModel() { DivisionId = 2, DivisionName = "Division2" });
    
          UserModel user = new UserModel() { Username = "testUser", Address = "testAddress" };
    
          return View(new UserViewModel() { User = user, Divisions = divisions });
       }
    }
