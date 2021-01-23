        public static bool IsUniqueList(IEnumerable<int> values)
        {
            HashSet<int> check = new HashSet<int>();
            foreach (int value in values)
            {
                // adding to hashset returns true if item was added
                // and false if item is already present
                if (!check.Add(value)) return false;
            }
            return true;
        }
