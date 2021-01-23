        public IList<T> Filter<T>(IList<T> list)
        {
            var result = new List<T>();
            result.Add(list[0]); // Or whatever filtering method
            return result;
        }
