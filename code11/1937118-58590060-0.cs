    static class MyData
    {
        private static ConcurrentDictionary<string, Lot> _inventory = new ConcurrentDictionary<string, Lot>();
        public static Update(string lotId, Lot lot)
        {
            // Add your interception code here
            _inventory[lotId] = lot;
        }
    }
