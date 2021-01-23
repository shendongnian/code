    public class Page
    {
      public int ID { get; set; }
      public string Description{ get; set; }
      public int ParentID  {get; set; }
      public Page Parent { get; set; }
    
    }
