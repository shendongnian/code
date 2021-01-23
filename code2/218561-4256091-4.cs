    public class Person
    {
       [Required]
       public string FirstName { get; set; }
     
       [Required]
       public string LastName { get; set; }
     
       [Required]
       [Range(0, 100)]
       public int Age { get; set; }
    }
