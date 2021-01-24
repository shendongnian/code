    public class A
    {
       public int AId { get; set; }
       
       public virtual B B1 { get; set; }
       public virtual B B2 { get; set; }
    }
    
    public class B
    {
       public int BId { get; set; }
      
       public virtual ICollection<A> RawA1 { get; private set; } = new List<A>();
       public virtual ICollection<A> RawA2 { get; private set; } = new List<A>();
    
       [NotMapped]
       public A A
       {
          get { return RawA1.SingleOrDefault() ?? RawA2.SingleOrDefault(); }
       }
    }
