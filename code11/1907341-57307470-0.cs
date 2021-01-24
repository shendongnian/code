    public class Entity1 
    {
      [Key]
      public int Id { get; set; }
      public int Entity2ID { get; set; }
      public virtual Entity2 Entity2 { get; set; }
    }
