    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
    [BindProperty]
    public List<UserRoleViewModel> UserRoleViewModels { get; set; }
    public async Task<IActionResult> OnGetAsync(int? id, string roleId)
    {
        //...your logic
        var model = new List<UserRoleViewModel>();
        var userRoleViewModel = new UserRoleViewModel
        {
            UserId = "1",
            UserName = "aa",
            IsSelected = true
        };
        model.Add(userRoleViewModel);
        var userRoleViewModel2 = new UserRoleViewModel
        {
            UserId = "2",
            UserName = "bb",
            IsSelected = true
        };
        model.Add(userRoleViewModel2);
        UserRoleViewModels = model;// pass the model to the bind property
        return Page();
    }
