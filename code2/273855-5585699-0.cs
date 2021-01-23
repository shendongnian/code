    public class User
    {
    	[Key]
    	public Guid UserId { get; set; }
    	public string UserName { get; set; }
    }
    public class UserDetail
    {
    	[Key]
    	public Guid UserId { get; set; }
    	public string FullName { get; set; }
    	public string CompanyName { get; set; }
    }
    public class UserMembership
    {
    	[Key]
    	public Guid UserId { get; set; }
    	public string Password { get; set; }
    	public string Email { get; set; }
    	public bool IsApproved { get; set; }
    	public bool IsLockedOut { get; set; }
    }
