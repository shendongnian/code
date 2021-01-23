    class Region
    {
        static readonly RegionMap = new Dictionary<int,string>
        {
            { 1, "US" },
            { 2, "US" },
            { 3, "Canada" }
            { 4, "Canada" }
        }
    
        public static string GetRegion(int code)
        {
            string name;
            if (!RegionMap.TryGetValue(code, out name)
            {
                // Error handling here
            }
            return name;
        }
    }
