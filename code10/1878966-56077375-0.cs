    public class ItemTaxPreference
    {
        public string tax_specification { get; set; }
        public int tax_type { get; set; }
        public string tax_name { get; set; }
        public int tax_percentage { get; set; }
        public string tax_id { get; set; }
    }
    
    public class Item
    {
        public string item_id { get; set; }
        public string name { get; set; }
        public string image_document_id { get; set; }
        public string item_name { get; set; }
        public string hsn_or_sac { get; set; }
        public string sku { get; set; }
        public string image_name { get; set; }
        public string status { get; set; }
        public string source { get; set; }
        public bool is_linked_with_zohocrm { get; set; }
        public string zcrm_product_id { get; set; }
        public string description { get; set; }
        public List<ItemTaxPreference> item_tax_preferences { get; set; }
        public double rate { get; set; }
        public string tax_id { get; set; }
        public string reorder_level { get; set; }
        public string tax_name { get; set; }
        public int tax_percentage { get; set; }
        public string purchase_account_id { get; set; }
        public string purchase_account_name { get; set; }
        public string account_name { get; set; }
        public string unit { get; set; }
        public string purchase_description { get; set; }
        public int purchase_rate { get; set; }
        public string item_type { get; set; }
        public string product_type { get; set; }
        public bool is_taxable { get; set; }
        public string tax_exemption_id { get; set; }
        public string tax_exemption_code { get; set; }
        public bool has_attachment { get; set; }
        public bool is_combo_product { get; set; }
        public DateTime created_time { get; set; }
        public DateTime last_modified_time { get; set; }
        public bool track_serial_number { get; set; }
        public int? stock_on_hand { get; set; }
        public string cf_category { get; set; }
        public string cf_maximum_retail_price_mrp { get; set; }
    }
    
    public class PageContext
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public bool has_more_page { get; set; }
        public string report_name { get; set; }
        public string applied_filter { get; set; }
        public List<object> custom_fields { get; set; }
        public string sort_column { get; set; }
        public string sort_order { get; set; }
    }
    
    public class RootObject
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<Item> items { get; set; }
        public PageContext page_context { get; set; }
    }
