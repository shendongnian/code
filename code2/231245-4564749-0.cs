    // No idea what a better name for this would be...
    class MaxAmountGrouper
    {
        readonly int _max;
    
        int _id;
        int _current;
        
        public MaxAmountGrouper(int max)
        {
            _max = max;
        }
    
        public int GetGroupId(int amount)
        {
            _current += amount;
            if (_current >= _max)
            {
                _current = 0;
                return _id++;
            }
            return _id;
        }
    }
