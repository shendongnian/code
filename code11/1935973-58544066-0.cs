    public class Machine
    {
      [Key]
      public int Id { get; set; }
        
      [Column(TypeName = "integer")]
      public MinutesAndSecondsTime Delay { get; set; }
        
      [Column(TypeName = "integer")]
      public MinutesAndSecondsTime Runtime { get; set; }
    }
