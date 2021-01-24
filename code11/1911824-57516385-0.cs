    [Table("tbl_items")]
    public class EbayItem
    {
        [Key]
        public int Item_ID { get; set; }
        public string Item { get; set; }
        public string Category { get; set; }
        public int Bids { get; set; }
    
        public int User_ID { get; set; }
        [ForeignKey("User_ID")]
        public virtual EbayUser User { get; set; }
    }
