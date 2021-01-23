        public static List<List<T>> InsideOutFlip<T>(this List<List<T>> values)
        {
            if (values.Count == 0 || values[0].Count == 0)
            {
                return new List<List<T>>();
            }
            int innerCount = values[0].Count;
            var flippedList = new List<List<T>>();
            foreach (int innerIndex in Enumerable.Range(0, innerCount))
            {
                List<T> valuesByOneInner = values.Select(value => value[innerIndex]).ToList();
                flippedList.Add(valuesByOneInner);
            }
            return flippedList;
        }            
