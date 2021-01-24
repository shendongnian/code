class DbResult
{
   public string Name { get; set; }
   public DateTime SubPortfolioInstanceID { get; set; }
   [Column("Status")]
   private Int32 HiddenStatus { get; set; }
   public Boolean Status => this.HiddenStatus != 0;
 }
