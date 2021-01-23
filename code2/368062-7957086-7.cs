    // An interface that is based on IEquatable for better compatibility but also
    // enables you to create a diferent EqualsTo method...
    public interface IData<T> : IEquatable<T>
    {
       T GetData();
       int GetDataHash();
       bool EqualsTo(IData<T> other);
    }
    // One class (string)
    public class StringData : IData<string>
    {
       private string Value { get; set; }
       public StringData(string value) { Value = value; }
       public string GetData() { return Value; }
       public int GetDataHash() { return GetData().GetHashCode(); }
       // From IEquatable
       public bool Equals(string other)
       { return Value.Equals(other); }
       // From IData (customized to compare the hash from raw value)
       public bool EqualsTo(IData<string> other)
       { return GetDataHash() == other.GetDataHash(); }
    }
    // Another class (int)
    public class IntData : IData<int>
    {
       private int Value { get; set; }
       public IntData(int value) { Value = value; }
       public int GetData() { return Value; }
       public int GetDataHash() { return GetData().GetHashCode(); }
       // Again from IEquatable
       public bool Equals(int other)
       { return Value == other; }
       // Again from IData (customized to compare just the hash code)
       public bool EqualsTo(IData<int> other)
       { return GetDataHash() == other.GetDataHash(); }
    }
