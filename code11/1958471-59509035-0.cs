    class Classroom
    {
          [Key]
          [Column(Order = 0)]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
          ....
    }
