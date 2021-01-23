        var repositoryMock = mocks.StrictMock<IUserRepository>();
        var activeUsers = new List<User>();
        for (int i = 0; i < 10; i++)
        {
            var user = UserMocks.CreateUser();
            user.IsActive = true;
            activeUsers.Add(user);
        }
        Expect.Call(repositoryMock.GetActiveUsers()).Return(activeUsers);
    The actual code is a lot more concise, but you get the idea.
