    public async void GetUserInfo()
    {
            var user = await _userManager.GetUserAsync(User);
            var email = user.Email;
    }
