      public class Lot
      {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int LotNumber { get; set; }
            public string LotName { get; set; }
       }
