    class A
    {
      private B obj1, obj2;
      public B Obj1 
      { 
        get { return obj1; }
        set 
        {
          if (value != null && value.Owner != null)
            throw new ArgumentException();
          if (obj1 != null)
            obj1.Owner = null;
          obj1 = value;
          obj1.Owner = "Obj1";
        }
      }
      public B Obj2
      {
        get { return obj2; }
        set
        {
          if (value != null && value.Owner != null)
            throw new ArgumentException();
          if (obj2 != null)
            obj2.Owner = null;
          obj2 = value;
          obj2.Owner = "Obj2";
        }
      }
    }
    class B
    {
      public string Owner { get; internal set; }
      // ...
    }
