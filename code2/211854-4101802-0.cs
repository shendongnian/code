    public class source
    {
      public int _myfield;
    
      public string MyField
      {
        get
        {
           return _myfield.ToString();
        }
      }
    }
    public class destination
    {
      public string MyField { get; set; }
    }
