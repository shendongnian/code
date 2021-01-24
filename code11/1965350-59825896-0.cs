    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    ....
    public partial class Person
    {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int ID { get; set; }
    
      public string FirstName { get; set; }
      public int Age { get; set; }
    }
