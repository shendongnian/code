    #nullable enable
    class Foo
    {
      public int? Val { get; set; }
      public string Name { get; set; }
      public bool HasName => Name != null;
      public bool HasValue => Val != null;
      public void NameToUpperCase()
      {
        if (HasName)
        {
          Name = Name.ToUpper();
        }
      }
      public void DoubleUp()
      {
        if (HasValue)
        {
          Val *= 2;
        }
      }
    }
