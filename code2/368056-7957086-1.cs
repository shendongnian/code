    public interface IData : IEquatable<IData> { }
    public class IntegerData : IData
    {
       // The value will be private for this example
       // Could be public int Value { get; private set; }
       private int Value { get; set; }
       // Constructor
       public IntegerData(int value) { Value = value; }
       
       // Implements Equals (from IEquatable - IData)
       public bool Equals(IData other) 
       { return Value.Equals(other.Value); }
    }
