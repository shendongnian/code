	public sealed class SearchQueryDto
	{
		private const int DefaultLimit = 10;
		private const int DefaultOffset = 0;
			
		public string Query { get; set; }
		public string PhoneNumber { get; set; }
		public string ClassificationId { get; set; }
		public int Offset { get; set; } = DefaultOffset;
		public int Limit { get; set; } = DefaultLimit;
		
		public bool IsDefault
		{
			get
			{
				return string.IsNullOrEmpty(Query)
					&& string.IsNullOrEmpty(PhoneNumber)
					&& string.IsNullOrEmpty(ClassificationId)
					&& Offset == DefaultOffset
					&& Limit == DefaultLimit;
			}
		}	
	}
