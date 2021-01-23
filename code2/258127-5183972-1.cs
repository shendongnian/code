    sealed class SimpleObject()
    {
        // No characteristics, all instances equal.
        public override bool Equals(object obj)
        {
            return obj is SimpleObject;
        }
    
        public override int GetHashCode()
        {
            return 0;
        }
    }
