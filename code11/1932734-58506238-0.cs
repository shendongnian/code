    public class TransactionRequest<T> {
        public string type { get; set; }
        public long amount { get; set; }
        public long tax_amount { get; set; }
        public long shipping_amount { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public string order_id { get; set; }
        public string po_number { get; set; }
        public string ip_address { get; set; }
        public bool email_receipt { get; set; }
        public string email_address { get; set; }
        public bool create_vault_record { get; set; }
        public Dictionary<string, T> payment_method { get; set; }
        public Address billing_address { get; set; }
        public Address shipping_address { get; set; }
    }
    public class Address {
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
