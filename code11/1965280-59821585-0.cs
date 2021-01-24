    public class Audit
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id { get; set; }  //instead of Pk 
       [NotMapped]
       public string Pk => Id.ToString();
 
       .  
       .
       .
    }
