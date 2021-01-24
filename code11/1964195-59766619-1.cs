    class CustomComparer : IEqualityComparer<YourObjectType> 
    { 
        public bool Equals(YourObjectType first, YourObjectType second) 
        { 
            if (first.Hash.Equals(second.Hash)) 
                return true; 
            else return false;
        }
        public int GetHashCode(YourObjectType obj)
        {
            throw new NotImplementedException();
        }        
    }
