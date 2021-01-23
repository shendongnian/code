    public class Owner
    {
        public string Name;
        public string OtherData;
      
        public override Equals(object other)
        {
            if (ReferenceEquals(this, other))
                return true;
    
            if (other == null)
                return false;
    
            return Name == other.Name && OtherData == other.OtherData;
        }
    
        public override int GetHashCode()
        {
            int hashCode = 0;
    
            unchecked
            {
               // whatever hash code computation you want, but for example...
                hashCode += 13 * Name != null ? Name.GetHashCode() : 0;
                hashCode += 13 * OtherData != null ? OtherData.GetHashCode() : 0;
            }
    
            return hashCode;
        }
    }
