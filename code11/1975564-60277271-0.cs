    public async Task GetInfo()
    {
        var user = await _userManager.GetUserAsync(Context.User);
        await Clients.User(user.Id).SendCoreAsync("msg", new object[] { user.Id, user.Email });
    }
