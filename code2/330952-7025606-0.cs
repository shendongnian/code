    public class S7_Baskets
    {
       [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
       [Column(Order = 0)]
       public string S7_BasketID { get; set; }
       [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
       [Column(Order = 1)]
       public int S7_Seqno { get; set; }
       [ForeignKey("S2_Products")]
       public int S7_ProductID { get; set; }
       public virtual S2_Products S2_Product { get; set; }
