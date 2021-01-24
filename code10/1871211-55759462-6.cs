    public class UserService
        {
            public UserService(IDatabaseSessions databaseSessions) : base(new Repository<User>(databaseSessions))
            {
            }
    }
