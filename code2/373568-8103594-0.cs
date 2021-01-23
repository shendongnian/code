    // Please don't use camelCased type names...
    // I'd probably use UserId, CustomerId etc, partly to avoid non-interfaces
    // starting with I.
    public struct IdUser : IComparable, IComparable<IdUser>, IEquatable<IdUser>
    {
       ...
       public bool Equals(IdUser other) { return m_Main == other.m_Main; }
       public int CompareTo(IdUser other) { return m_Main.CompareTo(other.mMain); }
    }
