        public bool Equals(YourClass other)
        {
            if (Object.Equals(this, other))
            {
                return true;
            }
            else
            {
                if(Name == other.Name && Value == other.Value)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
     public override int GetHashCode()
     {
         return Name.GetHashCode() ^ Value.GetHashCode();
     }
    }
