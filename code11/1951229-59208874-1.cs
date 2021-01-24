    public class UsersViewComponent : ViewComponent
    {
        private IUserService _userService;
        public UsersViewComponent(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var users = await _userService.GetUsersAsync();
            return View(users);
        }
    }
