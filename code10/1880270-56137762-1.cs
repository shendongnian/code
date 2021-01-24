	public class ItemAttribute
	{
		public string AttibuteName { get; set; }
		public string AttributeValue { get; set; }
	}
	public class SalesLine
	{
		public string SONumber { get; set; }
		public int LineNum { get; set; }
		public string ItemId { get; set; }
		public List<ItemAttribute> ItemAttributes { get; set; }
	}
	public class Value
	{
		public string documentType { get; set; }
		public string SONumber { get; set; }
		public List<SalesLine> SalesLines { get; set; }
	}
	public class RootObject
	{
		public List<Value> value { get; set; }
	}
