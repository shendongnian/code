    class Comparer : IEqualityComparer<String>
    {
    
        public bool Equals(String s1, String s2)
        {
            // will need to test for nullity
            return Reverse(s1).Equals(s2);
        }
    
        public int GetHashCode(String s)
        {
            // will have to implement this
        }
    
    }
