        private static List<IndexedDate> IndexTheDates(IEnumerable<DateTime> dates)
        {
            List<IndexedDate> ret = new List<IndexedDate>();
            if (!dates.Any())
                return ret;
            var current = dates.First();
            int index = 1;
            foreach(var date in dates)
            {
                ret.Add(new IndexedDate(date, index++));
                if (date >= current + TimeSpan.FromDays(180))
                {
                    current = date;
                    index = 1;
                }
            }
            return ret;
        }
