    public class UserProfileController
    {
       [HttpGet]
       [OutputCache (Duration=60)]
       public ActionResult Index() // core user details
       {
           var userProfileModel = somewhere.GetSomething();
           return View(userProfileModel);
       }
    
       [HttpGet]
       public PartialViewResult DisplayRecentPosts(User user)
       {
           var recentPosts = somewhere.GetRecentPosts(user);
           return PartialViewResult(recentPosts);
       }
    }
