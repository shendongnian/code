        public static int? GetPreviousId(int startId)
        {
            return GetList()
                   .Where(m => m.Id == startId)
                   .Select(m => m.PrevId) 
                   .FirstOrDefault();
        }
