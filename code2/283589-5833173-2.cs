	public class Product : IEntity
	{
		[ReadOnly]
		public int Id { get; set; }
		
		public string Name { get; set; }
		public decimal Price { get; set; }
		
		[ReadOnly]
		public DateTime Created { get; set; }
		
		[ReadOnly]
		public DateTime Updated { get; set; }
	}
