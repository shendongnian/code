        public static bool HasNullOrEmpty(this IEnumerable<string> collection)
        {
            foreach (var item in collection)
            {
                if (string.IsNullOrEmpty(item))
                {
                    return true;
                }
            }
            return false;
        }
