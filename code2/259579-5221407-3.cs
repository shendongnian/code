       public override int GetHashCode()
       {
           unchecked // Overflow is fine, just wrap
           {
               int hash = 17;
               // Suitable nullity checks etc, of course :)
               hash = hash * 23 + X.GetHashCode();
               hash = hash * 23 + Y.GetHashCode();
               return hash;
           }
       }
