c#
public class ApplicationUser : IdentityUser
{
	[MaxLength(17)]
	[IsUnique]
	public string PhoneNumber { get; set; }
}
