    static class MockFactory
    {
    	public static Func<IUserDatabase> MockUserDatabase
    	{
    		get
    		{
    			return () =>
    			{
    				var mock = Mock.Create<IUserDatabase>();
    
    				mock
    					.Arrange(x => x.GetUsersAsync())
    					.Returns(new[] { new User { Name = "John" } }.ToTask());
    
    				return mock;
    			};
    		}
    	}
    }
