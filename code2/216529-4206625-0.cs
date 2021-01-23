    public class User
    {
        public User()
        {
            UserName = "";          //Stackoverflow on this line.
            EmailAddress = "";
            Creator = new User();
        }
        public String UserName { get; set; }
        public String EmailAddress { get; set; }
        public User Creator { get; set; }
    }
    //{Cannot evaluate expression because the current thread is in a stack overflow state.}
