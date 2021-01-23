    public interface IReadOnly
    {
      Data Value { get; }
    }
    internal interface IWritable : IReadOnly 
    {
      void SetValue(Data value);
    }
