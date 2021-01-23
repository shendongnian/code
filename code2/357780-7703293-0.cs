    public class Page
    {
      public int ID { get; set; }
      public string Description{ get; set; }
      public int? ParentID  {get; set; }
      public virtual Page Parent { get; set; }
    
    }
