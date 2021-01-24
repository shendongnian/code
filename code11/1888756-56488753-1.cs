    [Table("Table1")]
    public class Test 
    {
      public Guid Id { get; set; }
      [Column("% Column1")]
      public int Column1 { get; set; }
      [Column("$ Column2")]
      public int Column2 { get; set; }
      [Column("+ Column3")]
      public int Column3 { get; set; }
      [Column("- Column4")]
      public int Column4 { get; set; }
      [Column("# Column5")]
      public int Column5 { get; set; }
    }
