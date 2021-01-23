    public static class NullableInt32Extensions
    {
      public static bool HasValue(this NullableInt32 source)
      {
        return source != null;
      }
    }
    
    public partial class NullableInt32
    {
      public static implicit operator int? (NullableInt32 other)
      {
        return other == null ? (int?)null : other.Value;
      }
    
      public static implicit operator NullableInt32(int? other)
      {
        return other == null ? null : new NullableInt32 { Value = other.Value };
      }
    }
