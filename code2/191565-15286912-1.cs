    public class Class1
    {
      [Ignore]
      public bool IsRemoting { get; set; }
      [SerializeWhen("IsRemoting", true)]
      public Class2 B;
    }
