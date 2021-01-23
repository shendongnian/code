         protected bool Equals(x other) {
            return Row == other.Row && Col == other.Col && string.Equals(Value, other.Value);
         }
         public override bool Equals(object obj)
         {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((x) obj);
         }
         public override int GetHashCode()
         {
            unchecked
            {
               var hashCode = Row;
               hashCode = (hashCode*397) ^ Col;
               hashCode = (hashCode*397) ^ (Value != null ? Value.GetHashCode() : 0);
               return hashCode;
            }
         }
