    class TestType
    {
      public int Id { get; set; }
      public string Value { get; set; }
      public TestType(int id, string value)
      {
        Id = id;
        Value = value;
      }
    }
    class TestAttribute : Attribute
    {
      public TestAttribute(params TestType[] array)
      {
        //
      }
    }
