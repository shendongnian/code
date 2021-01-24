     public class User
    {
    public string Email { get; set;}
    public string PasswordSalt { get; set;}
    public User()
    {
        PasswordSalt = string.IsNullOrEmpty(PasswordSalt)? "some random value":PasswordSalt;
    }
    }
