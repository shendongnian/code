    var users = _userService.GetUsers();
    var model = new List<UserViewModel>();
    foreach (var user in users)
    {
        model.Add(new UserViewModel
        {
            UserName = user.Username,
            Enabled = user.Enabled
        };
    }
