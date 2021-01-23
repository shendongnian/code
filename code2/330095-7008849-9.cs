    public class  Pais
    {
        public int Id { get; set; }
        public virtual ICollection<UF> UFs { get; set; }
    } 
    public class UF
    {
      public int Id { get; set; }
      public virtual Pais Pais { get; set; }
      public int PaisId { get; set; }
    }  
