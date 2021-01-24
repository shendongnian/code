	public partial class RootObject
	{
		[JsonProperty("itemDetails")]
		public ItemDetail[] ItemDetails { get; set; }
		[JsonProperty("purchaserEmail")]
		public string PurchaserEmail { get; set; }
		[JsonProperty("purchaserName")]
		public string PurchaserName { get; set; }
		[JsonProperty("recipientDetails")]
		public RecipientDetails RecipientDetails { get; set; }
		[JsonProperty("disableAllEmails")]
		public object DisableAllEmails { get; set; }
		[JsonProperty("orderDate")]
		public object OrderDate { get; set; }
	}
	public partial class ItemDetail
	{
		[JsonProperty("quantity")]
		public long Quantity { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("description")]
		public object Description { get; set; }
		[JsonProperty("code")]
		public object Code { get; set; }
		[JsonProperty("price")]
		public double Price { get; set; }
		[JsonProperty("value")]
		public double Value { get; set; }
		[JsonProperty("expiresOn")]
		public object ExpiresOn { get; set; }
		[JsonProperty("expiresInMonths")]
		public object ExpiresInMonths { get; set; }
		[JsonProperty("overrideExpiry")]
		public bool OverrideExpiry { get; set; }
		[JsonProperty("sku")]
		public string Sku { get; set; }
		[JsonProperty("id")]
		public object Id { get; set; }
	}
	public partial class RecipientDetails
	{
		[JsonProperty("recipientName")]
		public string RecipientName { get; set; }
		[JsonProperty("recipientEmail")]
		public string RecipientEmail { get; set; }
		[JsonProperty("message")]
		public string Message { get; set; }
		[JsonProperty("scheduledFor")]
		public DateTimeOffset ScheduledFor { get; set; }
	}
    
