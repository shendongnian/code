    public sealed class User : IDto
    {
    public String FirstName { get; private set; }
    public String LastName { get; private set; }
   
    public User(String firstName, String lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    }
