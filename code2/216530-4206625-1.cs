    public List<User> CreatUsers()
    {
        List<User> users = new List<User>;
        //Some DB call to get a list of users
        foreach (var record in userlist)
            List.Add(CreatUser(record));
    }
    public User CreateUser(?? record)
    {
        User user = new User();
        //Set properties
        if (record has creator) //pseudo-code
            user.Creator = CreatUser(record.Creator); //guessing as to record.Creator
    }
    public class User
    {
        public User()
        {
            UserName = "";          //Stackoverflow on this line.
            EmailAddress = "";
        }
        public String UserName { get; set; }
        public String EmailAddress { get; set; }
        public User Creator { get; set; }
    }
    //{Cannot evaluate expression because the current thread is in a stack overflow state.}
