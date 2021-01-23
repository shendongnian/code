       public class  Pais
       {
           public int Id { get; set; }
           public virtual ICollection<B> Bs { get; set; }
       }
    
       public class UF
       {
         public int Id { get; set; }
         public virtual Pais Pais { get; set; }
         public int PaisId { get; set; } //don't need this if you use the 2nd approach
       }
