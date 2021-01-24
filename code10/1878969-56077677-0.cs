    public class Product
    {
    	[JsonProperty("code")]
    	public int Code { get; set; }
    
    	[JsonProperty("message")]
    	public string Message { get; set; }
    
    	[JsonProperty("items")]
    	public List<Item> Items { get; set; }
    
    	[JsonProperty("page_context")]
    	public PageContext PageContext { get; set; }
    }
    
    public class PageContext
    {
    	[JsonProperty("page")]
    	public int Page { get; set; }
    
    	[JsonProperty("per_page")]
    	public int PerPage { get; set; }
    
    	[JsonProperty("has_more_page")]
    	public bool HasMorePage { get; set; }
    
    	[JsonProperty("report_name")]
    	public string ReportName { get; set; }
    
    	[JsonProperty("applied_filter")]
    	public string AppliedFilter { get; set; }
    
    	[JsonProperty("custom_fields")]
    	public object[] CustomFields { get; set; }
    
    	[JsonProperty("sort_column")]
    	public string SortColumn { get; set; }
    
    	[JsonProperty("sort_order")]
    	public string SortOrder { get; set; }
    }
    
    public class Item
    {
    	[JsonProperty("item_id")]
    	public string ItemId { get; set; }
    
    	[JsonProperty("name")]
    	public string Name { get; set; }
    
    	[JsonProperty("image_document_id")]
    	public string ImageDocumentId { get; set; }
    
    	[JsonProperty("item_name")]
    	public string ItemName { get; set; }
    
    	[JsonProperty("hsn_or_sac")]
    	public string HsnOrSac { get; set; }
    
    	[JsonProperty("sku")]
    	public string SKU { get; set; }
    
    	[JsonProperty("image_name")]
    	public string ImageName { get; set; }
    
    	[JsonProperty("status")]
    	public string Status { get; set; }
    
    	[JsonProperty("source")]
    	public string Source { get; set; }
    
    	[JsonProperty("is_linked_with_zohocrm")]
    	public bool IsLinkedWithZohocrm { get; set; }
    
    	[JsonProperty("zcrm_product_id")]
    	public string ZcrmProductId { get; set; }
    
    	[JsonProperty("description")]
    	public string Description { get; set; }
    
    	[JsonProperty("item_tax_preferences")]
    	public ItemTaxPreference[] ItemTaxPreferences { get; set; }
    
    	[JsonProperty("rate")]
    	public float Rate { get; set; }
    
    	[JsonProperty("tax_id")]
    	public string TaxId { get; set; }
    
    	[JsonProperty("reorder_level")]
    	public string ReorderLevel { get; set; }
    
    	[JsonProperty("tax_name")]
    	public string TaxName { get; set; }
    
    	[JsonProperty("tax_percentage")]
    	public int TaxPercentage { get; set; }
    
    	[JsonProperty("purchase_account_id")]
    	public string PurchaseAccountId { get; set; }
    
    	[JsonProperty("purchase_account_name")]
    	public string PurchaseAccountName { get; set; }
    
    	[JsonProperty("account_name")]
    	public string AccountName { get; set; }
    
    	[JsonProperty("unit")]
    	public string Unit { get; set; }
    
    	[JsonProperty("purchase_description")]
    	public string PurchaseDescription { get; set; }
    
    	[JsonProperty("purchase_rate")]
    	public int PurchaseRate { get; set; }
    
    	[JsonProperty("item_type")]
    	public string ItemType { get; set; }
    
    	[JsonProperty("product_type")]
    	public string ProductType { get; set; }
    
    	[JsonProperty("is_taxable")]
    	public bool IsTaxable { get; set; }
    
    	[JsonProperty("tax_exemption_id")]
    	public string TaxExemptionId { get; set; }
    
    	[JsonProperty("tax_exemption_code")]
    	public string TaxExemptionCode { get; set; }
    
    	[JsonProperty("has_attachment")]
    	public bool HasAttachment { get; set; }
    
    	[JsonProperty("is_combo_product")]
    	public bool IsComboProduct { get; set; }
    
    	[JsonProperty("created_time")]
    	public DateTime CreatedTime { get; set; }
    
    	[JsonProperty("last_modified_time")]
    	public DateTime LastModifiedTime { get; set; }
    
    	[JsonProperty("track_serial_number")]
    	public bool TrackSerialNumber { get; set; }
    
    	[JsonProperty("stock_on_hand")]
    	public int StockOnHand { get; set; }
    
    	[JsonProperty("cf_category")]
    	public string CfCategory { get; set; }
    
    	[JsonProperty("cf_maximum_retail_price_mrp")]
    	public string CfMaximumRetailPriceMRP { get; set; }
    }
    
    public class ItemTaxPreference
    {
    	[JsonProperty("tax_specification")]
    	public string TaxSpecification { get; set; }
    
    	[JsonProperty("tax_type")]
    	public int tax_type { get; set; }
    
    	[JsonProperty("tax_name")]
    	public string TaxName { get; set; }
    
    	[JsonProperty("tax_percentage")]
    	public int TaxPercentage { get; set; }
    
    	[JsonProperty("tax_id")]
    	public string TaxId { get; set; }
    }
