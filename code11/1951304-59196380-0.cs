    class TagEqualityComparer : IEqualityComparer<Tag>
    {
        public bool Equals(Tag t1, Tag t2)
        {
            if (t2 == null && t1 == null)
               return true;
            else if (t1 == null || t2 == null)
               return false;
            else if(t1.Id == t2.Id)
                return true;
            else
                return false;
        }
    
        public int GetHashCode(Tag t)
        {
            // any custom hashingfunction here
        }
    }
