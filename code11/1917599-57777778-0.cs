       public abstract class Profile : IEquatable<Profile>
      {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Equals(Profile other)
	   {
		   return this.Email == other.Email;
	    }
     }
    public class Auth0Profile : Profile
    {
	
	   public string Connection { get; set; }
	   public string Password { get; set; }
	   public bool VerifyEmail { get; set; }
    }
    public class SharePointProfile : Profile
    {
	   public int Id { get; set; }
	   public string Title { get; set; }
	   public bool IsSiteAdmin { get; set; }
    }
