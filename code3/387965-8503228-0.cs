    class DialectQuery : IEquatable<DialectQuery>
    {
      public Dialect{get;private set}
      public Name{get;private set;}
      public DialectQuery(string dialect, string name)
      {
        Dialect = dialect;
        Name = name;
      }
      public bool Equals(DialectQuery other)
      {
        return other != null && Name == other.Name && Dialect == other.Dialect;
      }
      public override bool Equals(object other)
      {
        return Equals((object)other);
      }
      public override int GetHashCode()
      {
        int dHash = Dialect.GetHashCode();
        return (dHash << 16 | dHash >> 16) ^ Name.GetHashCode();
      }
    }
