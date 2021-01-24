    public class cart_row
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? id_cartRow_fictive { get; set; }
        public long? id_product { get; set; }
        public int quantity { get; set; }
        ....
        public long? id_cart {get; set;}
        public cart cart {get; set;}
    }
