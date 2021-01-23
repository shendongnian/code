    [WebMethod]
    public Result Foo()
    {
        return new Result
        {
            Success = 1, // a boolean seems more adapted for this instead of integer
            Users = new[]
            {
                new User { Name = "Michael", Age = 10 },
                new User { Name = "Barbara", Age = 25 },
            }
        };
    }
