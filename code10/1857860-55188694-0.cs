    public class AccountController : Controller
	 {
	  public ActionResult UserList(string username)
	  {
		using (UsersContext db = new UsersContext())
		{
			var username = db.UserProfile.Select(x => x.UserName ).ToList();
			return View(username)
		}    
	  } 
