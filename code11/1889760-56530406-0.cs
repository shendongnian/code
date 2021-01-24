	interface DocumentLine { }
	class BillLine : DocumentLine { }
	class ReceiptLine : DocumentLine { }
	
	class Document<T> where T : DocumentLine
	{
		public List<T> Lines { get; set; }
	}
	
	class Bill : Document<BillLine>	{ }
	
	class Receipt : Document<ReceiptLine>	{ }
