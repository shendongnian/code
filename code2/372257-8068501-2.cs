    public static MinMaxHelper()
    {
        public static int? MaxOrDefault(IEnumerable<int> ints)
        {
            if(!ints.Any())
            {
                return null;
            }
    
            return ints.Max();
        }
    
        public static int MaxOrDefault(IEnumerable<int> ints, int defaultValue)
        {
            if(!ints.Any())
            {
                return defaultValue;
            }
    
            return ints.Max();
        }
    
        public static int? MinOrDefault(IEnumerable<int> ints)
        {
            if(!ints.Any())
            {
                return null;
            }
    
            return ints.Min();
        }
    
        public static int MinOrDefault(IEnumerable<int> ints, int defaultValue)
        {
            if(!ints.Any())
            {
                return defaultValue;
            }
    
            return ints.Min();
        }
    }
