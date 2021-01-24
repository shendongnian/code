 c#
public class User
{
    // Parameter def
    public string Class {get;set;}
    public string Username {get;set;}
    public DateTime LoginDate {get;set;}
    private string Password {get;set;} // mutters something about "salted hashes"
}
...
cnn.Execute("insert into Users (stUsername, stClass, LoginDate) values (@Username, @Class, @LoginDate)", uUser);
(you don't *have* to change the names... but I just can't type `public string stClass {get;set;}` without wincing)
