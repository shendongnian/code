    public class SomeItem
    {
      private string _Value;
      private int _Version = 0;
      private int _LastKnown = 0;
  
      public SomeItem()
      {
  
      }
  
      public SomeItem(string value)
      {
         this._Value = value
      }
  
  
      public string Value
      {
         get { return this._Value; }
         set { if (this._Value != value) { this._Value = value; this._Version++; } }
      }
  
      public int Version
      {
        get { return this._Version; }
      }
  
      public bool HasChanged
      {
         get { return (this._Version != _LastKnown); }
      }
    
     // Reset change tracking.
     public void Reset()
     {
        this._LastKnown = this._Version;
     }
    }
