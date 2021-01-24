    class CustomComparer : IEqualityComparer<YourObjectType> 
    {  
         
        public bool Equals(YourObjectType first, YourObjectType second) 
        {  
            if (first == null | second == null) { return false; } 
            else if (first.Hash == second.Hash) 
                return true; 
            else return false;
        }
        public int GetHashCode(YourObjectType obj)
        {
            throw new NotImplementedException();
        }        
    }
