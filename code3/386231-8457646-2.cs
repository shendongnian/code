    public class ParamID : IEquatable<ParamID> // IEquatable makes this faster
    {
      private readonly string _first; //not necessary, but immutability of keys prevents other possible bugs
      private readonly string _second;
      public ParamID(string first, string second)
      {
        _first = first;
        _second = second;
      }
      public bool Equals(ParamID other)
      {
        //change for case-insensitive, culture-aware, etc.
        return other != null && _first == other._first && _second == other._second;
      }
      public override bool Equals(object other)
      {
        return Equals(other as ParamID);
      }
      public override int GetHashCode()
      {
        //change for case-insensitive, culture-aware, etc.
        int fHash = _first.GetHashCode();
        return ((fHash << 16) | (fHash >> 16)) ^ _second.GetHashCode();
      }
    }
