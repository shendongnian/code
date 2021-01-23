	public class Item
	{
		public virtual Guid Id { get; set; }
		public virtual CountryType Country { get; set; }
		public virtual CategoryType Category { get; set; }
		...
		public virtual ISet< ItemNames > AlternateNames {get; set;}
		...
	}
