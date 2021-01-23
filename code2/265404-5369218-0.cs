	public class Account
	{
		public long ID { get; set; }
		public virtual User User { get; set; }
	}
	
	public class User
	{
		public long ID { get; set; }
		public virtual Account Account { get; set; }
	}
	
	public class Team
	{
		public long ID { get; set; }
		public long CompanyID { get; set; }
		public virtual Company Company { get; set; }
		public virtual ICollection<User> Users { get; set; }
	}
	
	public class Company
	{
		public long ID { get; set; }
	}
