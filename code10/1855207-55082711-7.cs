    public partial class MonthlyPrice
    {
        [Key]
        public int MpId { get; set; }        
    
        [ForeignKey("Markets")]
        public int MktId { get; set; }
        public Markets Mkt { get; set; }
        [ForeignKey("Commodities")]
        public int CmId { get; set; }
        public Commodities Cm { get; set; }
        public decimal MpPrice { get; set; }
        public Currencies Cur { get; set; }
        public PriceTypes Pt { get; set; }
        public UnitOfMeasure Um { get; set; }
    }
    public partial class Commodities
    {
        public Commodities()
        {
            MonthlyPriceItem = new HashSet<MonthlyPriceItem>();
        }
        [Key]
        public int CmId { get; set; }
        public string CmName { get; set; }
        public int CmCatId { get; set; }
        public ICollection<MonthlyPrice> MonthlyPriceItem { get; set; }
    }
    public partial class Markets
    {
        [Key]
        public int MktId { get; set; }
        public string MktName { get; set; }
    }
