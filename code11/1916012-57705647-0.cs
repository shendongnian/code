public partial class AspNetUsers : IdentityUser
{
    public AspNetUsers()
    {
    }
    public string Id { get; set; }
    public DateTime RegistrationTime { get; set; }    
}
