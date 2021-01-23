    public class Resource
    {
      public int Id {get; set; }
    
      [..]
    
      public virtual ICollection<ResourceTag> TagsSet { get; set; }
    }
