    public sealed class Thing : IEquatable<Thing>
    {
        public int Id{get;set;}
        public decimal ShouldMatch1 {get;set;}
        public int OtherMatch2{get;set;}
        public string DoesntMatter{get;set;}
        public int SomeOtherDoesntMatter{get;set;}
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + Id.GetHashCode() ;
            hash = hash * 31 + ShouldMatch1.GetHashCode() ;
            hash = hash * 31 + OtherMatch2.GetHashCode() ;
            return hash;
        }
        public override bool Equals(object other) {
            return Equals(other as Thing);
        }
        public bool Equals(Thing other) {
            if (other == null) {
                return false;
            }
            return Id == other.Id &&
                   ShouldMatch1 == other.ShouldMatch1 &&
                   OtherMatch2 == other.OtherMatch2;
        }
    }
