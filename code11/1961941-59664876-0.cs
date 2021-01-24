    class LongArrayComparer : EqualityComparer<long[]> 
    {
        public override bool Equals(long[] a1, long[] a2)
        {
            if (a1 == null && a2 == null)
                return true;
            else if (a1 == null || a2 == null)
                return false;
    
            return a1.SequenceEqual(a2);
        }
    
        public override int GetHashCode(long[] arr)
        {
            long hCode = arr.Aggregate(0, (acc, it) => acc ^ it);
            return hCode.GetHashCode();
        }
    }
