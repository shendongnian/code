    public class BonusCard
    {
       
        [Key]
        public int Id { get; set; }
        public string User_id { get; set; }
        [ForeignKey("User_id")]
        public virtual ApplicationUser User { get; set; }
        public string Code { get; set; }
        public DateTime CreationDate { get; set; } = (DateTime)SqlDateTime.MinValue;
        public DateTime UsageDate { get; set; } = (DateTime)SqlDateTime.MinValue;
        public int? Player_id { get; set; } = null;
        [ForeignKey("Player_id")]
        public virtual Player Player { get; set; }
        public int PromoCard_id { get; set; }
        [NotMapped]
        public  PromoCard PromoCard { get { return PromoCards[PromoCard_id]; } set { } }
    }
