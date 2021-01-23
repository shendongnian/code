    public class Widget
    {
      private int MyPropertyBackingStore ;
      public int MyProperty
      {
        get
        {
          return this.MyPropertyBackingStore ;
        }
        set
        {
          if ( this.MyPropertyBackingStore.HasValue && this.MyPropertyBackingStore > 0 )
          {
            this.MyPropertyBackingStore = value ;
          }
          else
          {
            this.MyPropertyBackingStore = -1 ;
          }
        }
      }
    }
