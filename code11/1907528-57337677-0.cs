    public class Vendor_Details
    {
        public Vendor_Details()
        {
            Items = new HashSet<Items_List>();
        }
        public int Id { get; set; }
        public string Vendor_Name { get; set; }
        public string Vendor_Code { get; set; }
        public string Vendor_Email { get; set; }
        public ICollection<Items_List> Items { get; set; }
    }
    public class Items_List
    {
        public int Id { get; set; }
        public string Item_Name { get; set; }
        public string Description { get; set; }
        public decimal Item_Price { get; set; }
        public int Vendor_Id { get; set; }
        [ForeignKey("Vendor_Id")]
        public Vendor_Details Vendor { get; set; }
    }
