    public class ReturnValues
    {
    	public class Card
    	{
    		public string id { get; set; }
    		public string card_type { get; set; }
    		public string first_six { get; set; }
    		public string last_four { get; set; }
    		public string masked_card { get; set; }
    		public string expiration_date { get; set; }
    		public string response { get; set; }
    		public int response_code { get; set; }
    		public string auth_code { get; set; }
    		public string processor_response_code { get; set; }
    		public string processor_response_text { get; set; }
    		public string processor_transaction_id { get; set; }
    		public string processor_type { get; set; }
    		public string processor_id { get; set; }
    		public string avs_response_code { get; set; }
    		public string cvv_response_code { get; set; }
    		public object processor_specific { get; set; }
    		public string created_at { get; set; }
    		public string updated_at { get; set; }
    	}
    
    	public class ResponseBody
    	{
    		public Card card { get; set; }
    	}
    
    	public class CustomFields
    	{
    	}
    
    	public class BillingAddress
    	{
    		public string first_name { get; set; }
    		public string last_name { get; set; }
    		public string company { get; set; }
    		public string address_line_1 { get; set; }
    		public string address_line_2 { get; set; }
    		public string city { get; set; }
    		public string state { get; set; }
    		public string postal_code { get; set; }
    		public string country { get; set; }
    		public string phone { get; set; }
    		public string fax { get; set; }
    		public string email { get; set; }
    	}
    
    	public class ShippingAddress
    	{
    		public string first_name { get; set; }
    		public string last_name { get; set; }
    		public string company { get; set; }
    		public string address_line_1 { get; set; }
    		public string address_line_2 { get; set; }
    		public string city { get; set; }
    		public string state { get; set; }
    		public string postal_code { get; set; }
    		public string country { get; set; }
    		public string phone { get; set; }
    		public string fax { get; set; }
    		public string email { get; set; }
    	}
    
    	public class Data
    	{
    		public string id { get; set; }
    		public string user_id { get; set; }
    		public string user_name { get; set; }
    		public string merchant_id { get; set; }
    		public string idempotency_key { get; set; }
    		public int idempotency_time { get; set; }
    		public string type { get; set; }
    		public int amount { get; set; }
    		public int base_amount { get; set; }
    		public int amount_authorized { get; set; }
    		public int amount_captured { get; set; }
    		public int amount_settled { get; set; }
    		public int amount_refunded { get; set; }
    		public int payment_adjustment { get; set; }
    		public int tip_amount { get; set; }
    		public string settlement_batch_id { get; set; }
    		public string processor_id { get; set; }
    		public string processor_type { get; set; }
    		public string processor_name { get; set; }
    		public string payment_method { get; set; }
    		public string payment_type { get; set; }
    		public List<string> features { get; set; }
    		public int national_tax_amount { get; set; }
    		public int duty_amount { get; set; }
    		public string ship_from_postal_code { get; set; }
    		public string summary_commodity_code { get; set; }
    		public string merchant_vat_registration_number { get; set; }
    		public string customer_vat_registration_number { get; set; }
    		public int tax_amount { get; set; }
    		public bool tax_exempt { get; set; }
    		public int shipping_amount { get; set; }
    		public int surcharge { get; set; }
    		public int discount_amount { get; set; }
    		public string currency { get; set; }
    		public string description { get; set; }
    		public string order_id { get; set; }
    		public string po_number { get; set; }
    		public string ip_address { get; set; }
    		public string transaction_source { get; set; }
    		public bool email_receipt { get; set; }
    		public string email_address { get; set; }
    		public string customer_id { get; set; }
    		public string customer_payment_type { get; set; }
    		public string customer_payment_ID { get; set; }
    		public string subscription_id { get; set; }
    		public string referenced_transaction_id { get; set; }
    		public ResponseBody response_body { get; set; }
    		public CustomFields custom_fields { get; set; }
    		public object line_items { get; set; }
    		public string status { get; set; }
    		public string response { get; set; }
    		public int response_code { get; set; }
    		public BillingAddress billing_address { get; set; }
    		public ShippingAddress shipping_address { get; set; }
    		public string created_at { get; set; }
    		public string updated_at { get; set; }
    		public string captured_at { get; set; }
    		public object settled_at { get; set; }
    	}
    
    	public class RootObject
    	{
    		public string status { get; set; }
    		public string msg { get; set; }
    		public Data data { get; set; }
    	}
    }
