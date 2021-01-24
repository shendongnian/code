public class UserSet {
    public List<User> Users {get; set;}
}
public class User{
    public string UserName { get; set; }
    public string Password { get; set; }
}
And then, when you add a new user, you just create a new object with his username and password, and then add it to the list of all users.
