    public class Foo
    {
      public int? Id { get; set; }
    
      public bool IsNew
      {
        get
        {
            return (Id == null) || (Id == 0);
        }
      }
    }
