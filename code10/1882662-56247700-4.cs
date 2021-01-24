    [HttpGet]
    public async Task<ActionResult<ListUsersDto>> Get() {
        var users = await _userService.GetAllUsers();
        if(users == null || users.Users.Count == 0)
            return NoContent(); //Or some other relevant action result
        return users;
    }
