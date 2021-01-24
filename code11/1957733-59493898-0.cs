    class ViewModel
    {
        //Load Fields
        public int bol_num { get; set; }
        public string pro_num { get; set; }
        public string quote_num { get; set; }
        public string ref_num { get; set; }
        public Nullable<double> weight { get; set; }
        public Nullable<int> pieces { get; set; }
        public string commodity { get; set; }
        public Nullable<double> mileage { get; set; }
        public Nullable<decimal> carrier_rate { get; set; }
        public Nullable<decimal> customer_rate { get; set; }
        public Nullable<int> driver_id { get; set; }
        public Nullable<int> dispatch_id { get; set; }
        public Nullable<int> customer_id { get; set; }
        public Nullable<int> broker_id { get; set; }
        public Nullable<System.DateTime> pick_date { get; set; }
        public Nullable<System.TimeSpan> pick_time { get; set; }
        public Nullable<System.DateTime> drop_date { get; set; }
        public Nullable<System.TimeSpan> drop_time { get; set; }
        public Nullable<System.DateTime> last_updated_time { get; set; }
        public string load_status { get; set; }
        public Nullable<int> account_id { get; set; }
        //Driver Fields
        public string driverContact_name { get; set; }
        public string driverContact_phone { get; set; }
        public string driverContact_email { get; set; }
    }
