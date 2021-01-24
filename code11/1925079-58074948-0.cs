    public class PossiblyEmpty<T> where T : struct
    {
      private readonly bool hasValue;
      private readonly T value;
      public PossiblyEmpty(T value)
      {
        this.value = value;
        this.hasValue = true;
      }
      public PossiblyEmpty() { }
      public bool HasValue => hasValue;
      public T Value => hasValue ? value : throw new InvalidOperationException("No value");
    }
