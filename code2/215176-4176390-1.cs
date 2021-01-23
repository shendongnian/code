    [DataContract]
    public sealed class UserSummary : IDto
    {
    [DataMember]
    public String FirstName { get; private set; }
    [DataMember]
    public String LastName { get; private set; }
    [DataMember]
    public UserProfile Profile { get; private set; }
   
    public UserSummary(String firstName, String lastName, UserProfile profile)
    {
        FirstName = firstName;
        LastName = lastName;
        Profile = profile;
    }
    }
