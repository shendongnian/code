    internal class KvpSLSEq : IEqualityComparer<KeyValuePair<string, List<string>>>
    {
      public bool Equals(KeyValuePair<string, List<string>> x, KeyValuePair<string, List<string>> y)
      {
        return x.Key == y.Key && x.Value.Count == y.Value.Count && x.Value.SequenceEquals(y.Value);
      }
      public int GetHashCode(KeyValuePair<string, List<string>> obj)
      {
        //you could just throw NotImplementedException unless you'll reuse this elsewhere.
        int hash = obj.Key.GetHashCode;
        foreach(string val in obj.Value)
           hash = hash * 31 + (val == null ? 0 : val.GetHashCode());
      }
    }
