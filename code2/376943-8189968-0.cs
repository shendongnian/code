    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDisplayAttribute : Attribute
    {
      public string Description { get; set; }
      public string Code { get; set; }
    }
