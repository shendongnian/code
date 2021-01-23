    public interface IMembershipAndRoleService
    {
        void ProcessNewUser(User newUser);
    }
    public class YourController : Controller
    {
        private readonly IMembershipAndRoleService _membershipAndRoleService;
        public YourController(IMembershipAndRoleService membershipAndRoleService)
        {
            _membershipAndRoleService = membershipAndRoleService;
        }
        [HttpPost]
        public ActionResult NewUserFormAction(NewUserForm newUserForm)
        {
            //process posted form, possibly map / convert it to User then call to save
            _membershipAndRoleService.ProcessNewUser(user);
            //redirect or return view
        }
    }
