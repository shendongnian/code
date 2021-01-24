    public async Task<int> RegisterUserAsync(UserCreateDto user)
    {
        using (var uow = UnitOfWorkProvider.Create())
        {
            var id = _userService.Create(user);
            await uow.Commit();
            return id(); // <-- the actual id!
        }
    }
