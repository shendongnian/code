    public delegate void VoidHandler(object sender);
    public class B // also C,D,E,...
    {
      // A.ItemChanged() will be wired to this SomethingChangedHandler.
      // I heard you are saving. Exclude SomethingChangedHandler from save.
      [field: NonSerialized]
      public VoidHandler SomethingChangedHandler;
      private c;
      public C
      {
        set
        {
          // unwire handler from old instance of C
          if(c != null)
            c.SomethingChangedHandler -= ItemChanged;
          // wire handler to new instance of C
          value.SomethingChangedHandler += ItemChanged;
          c = value;
          // setting c is also change which require notification
          ItemChanged(this);
        }
        get{}
      }
      // notify A about any change in B or in C
      void ItemChanged(object sender)
      {
        if(SomethingChangedHandler != null)
          SomethingChangedHandler(this);
      }
    }
