    public class Info : IEquatable<Info>
    {
        protected bool Equals(Info other)
        {
            return string.Equals(Id, other.Id) && string.Equals(Position, other.Position) && IsSet == other.IsSet;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Info) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Position != null ? Position.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ IsSet.GetHashCode();
                return hashCode;
            }
        }
        public string Id { get; set; }
        public string Position { get; set; }
        public bool IsSet { get; set; }
    }
