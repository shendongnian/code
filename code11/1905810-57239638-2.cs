    public class WorkExperienceController : Controller
    {
        // ... the rest of your code
    
        [ChildActionOnly] // An attribute which will prevent this action from being called by anything but Html.Action()
        public ActionResult DisplayWorkExperience(int? id)
        {
            TempData["EmployeeId"] = id;
            ViewBag.EmployeeId = id;
            
            return PartialView(); // this needs to return a partial view
        }
    
    }
