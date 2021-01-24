       public class Imbarco
       {
           [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
           public int ImbarcoID { get; set; }
           
           [InverseProperty("Imbarco")]
           public virtual ICollection<Barca> Barche { get; set; }
           [InverseProperty("ImbarcoBase")]
           public virtual ICollection<Barca> BaseBarche { get; set; }
        }
