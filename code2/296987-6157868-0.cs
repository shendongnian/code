    public class User
    {
        public static readonly UserAccess[] AccessList = {
                new UserAccess() { AccessLevel = "Admin",
                                   Commands = {".kick",".ban",".unban"}
                },
                new UserAccess() { AccessLevel = "User",
                                   Commands = {".add",".del"}
                },
                new UserAccess() { AccessLevel = "Vip",
                                   Commands = {".say"}
                }};
        public string Name { get; set; }
        public string Comments { get; set; }
        public string Access { get; private set; } //Assuming you can't modify this so we add the next property
        public UserAccess AccessLevel { get; private set; }
        public User(string access)
        {
            this.Access = access;
            this.AccessLevel = AccessList.FirstOrDefault(x => x.AccessLevel == access);
        }
    }
    public class UserAccess
    {
        public string AccessLevel { get; set; }
        public List<string> Commands = new List<string>();
        public bool HasCommand(string command)
        {
            return this.Commands.Any(x => x == command);
        }
    }
