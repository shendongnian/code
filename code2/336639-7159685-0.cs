    [Flags]
    public enum TestDTOFlags
    {
        None = 0,
        Old = 1,
        FromBataFamily = 2
    }
    public class TestableDTO : DTO 
    {
      public TestDTOFlags DetermineFlags() { /* some logic */ }
    }
