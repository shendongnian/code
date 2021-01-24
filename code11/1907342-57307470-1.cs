    public class Entity1 
    {
      [Key]
      public int Id { get; set; }
      [ForeignKey("Entity2")]
      public int Entity2ID { get; set; }
      public virtual Entity2 Entity2 { get; set; }
    }
