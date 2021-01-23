    public class ParamID : IEquatable<ParamID>
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
        if(other == null)
          return false;
        if(ReferenceEquals(this, other))
          return true;
        if(string.Compare(_first, other._first, StringComparison.InvariantCultureIgnoreCase) == 0 && string.Compare(_second, other._second, StringComparison.InvariantCultureIgnoreCase) == 0)
          return true;
        return string.Compare(_first, other._second, StringComparison.InvariantCultureIgnoreCase) == 0 && string.Compare(_second, other._first, StringComparison.InvariantCultureIgnoreCase) == 0;
      }
    }
