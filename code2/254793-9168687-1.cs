	public class Product
	{
		public int ProductId { get; set; }
		[Indexed("Main", 0)]
		public string ProductNumber { get; set; }
		[Indexed("Main", 1)]
		[Indexed("Second", direction: IndexDirection.Ascending)]
		[Indexed("Third", direction: IndexDirection.Ascending)]
		public string ProductName { get; set; }
        [String(4, 12, false)] //minLength, maxLength, isUnicode
		public string Instructions { get; set; }
		[Indexed("Third", 1, direction: IndexDirection.Descending)]
		public bool IsActive { get; set; }
		[Default("0")]
		public decimal? Price { get; set; }
		[Default("GetDate()")]
		public DateTime? DateAdded { get; set; }
		[Default("20")]
		public int Count { get; set; }
	}
