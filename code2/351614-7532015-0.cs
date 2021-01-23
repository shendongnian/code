    public class Widget
    {
      private int? MyPropertyBackingStore ;
      public int MyProperty
      {
        get
        {
          int value = 0 ; // the default value
          if ( this.MyPropertyBackingStore.HasValue && this.MyPropertyBackingStore > 0 )
          {
            value = this.MyPropertyBackingStore.Value ;
          }
          return value ;
        }
        set
        {
          this.MyPropertyBackingStore = value ;
        }
      }
    }
