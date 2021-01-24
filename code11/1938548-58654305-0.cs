`cs
public class AppUser : IdentityUser
{
    public int AddressId { get; set; }
    public UserAddress Address { get; set; }
}
public class UserAddress
{
    public int Id { get; set; }
    // ...
    public string UserId { get; set; }
    public AppUser User { get; set; }
}
`
Then replace IdentityUser in startup with AppUser :
`cs
services.AddDefaultIdentity<AppUser>();
`
Then create new migrations to create the new user table.
