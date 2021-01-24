    public class Vendor : DataAccess
    {
        //properties
        public int VEND_ID;
        public string VEND_NAME { get; set; }
        public string VEND_ADDRESS { get; set; }
        public string VEND_PHONE { get; set; }
        public string VEND_WEBSITE { get; set; }
        public string NOTES { get; set; }
        public List<Order> ORDERS { get; set; }
    
        public static string ErrorMessage { get; set; }
        //Constructors
        public Vendor(string name, string address, string phone, string website, string 
        notes)
        {
            VEND_NAME = name;
            VEND_ADDRESS = address;
            VEND_PHONE = phone;
            VEND_WEBSITE = website;
            NOTES = notes;
        }
        public Vendor(string name)
        {
            VEND_NAME = name;
        }
        public Vendor() { }
    }
    
    public class Order : DataAccess
            {
                //properties
                public int ORDER_ID { get; set; }
                public Vendor VENDOR_ID { get; set; }
                public string ENTRY_DATE { get; set; }
                public string ORDER_NO { get; set; }
                public string TOTAL_COST { get; set; }
                public string STATUS { get; set; }
                public string NOTES { get; set; }
                public string ATTACH_ID { get; set; }
                public static string ErrorMessage { get; set; }
                //constructors
                //public Order(string )
            }
     public Vendor GetVendorByName(string name)
            {
                using (IDbConnection connection = new 
                  SqlConnection(Helper.CnnVal("TESTDB")))
                {
                    var dict = new Dictionary<string, Vendor>();
    
                    var vendors = connection.Query<Vendor, Order, Vendor> 
                   ("dbo.GetVendor_ByName", (a, b) => Mapper(a, b, dict), new { 
                    VEND_NAME = name }, splitOn: "ORDER_ID");
    
                    return dict.Values.FirstOrDefault()
    
                }
            }
    
     public Vendor Mapper(Vendor vendor, Order order, Dictionary<string, Vendor> dict)
            {
                if (!dict.ContainsKey(vendor.VEND_NAME))
                {
                    vendor.ORDERS = new List<Order>();
                    dict.Add(vendor.VEND_NAME, vendor);
                }
                var currentVendor = dict[vendor.VEND_NAME];
    
                currentVendor.ORDERS.Add(order);
    
                return currentVendor;
            }
