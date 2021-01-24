    private Tuple<int, int> GetIfNotHandled(HashSet<Tuple<int, int>> existingItems, Tuple<int, int> range)
    {
            //first check if we find a full overlap with an existing item
            var fullOverlap = existingItems.FirstOrDefault(t => (t.Item1 <= range.Item1)
                                                             && (t.Item2 >= range.Item2));
            if (fullOverlap != null)
            {
                return null;
            }
            //look for a partial overlap, or the closest item below our range
            var lowerItem = existingItems.FirstOrDefault(t => (t.Item1 <= range.Item1) 
                                                           && (t.Item2 >= range.Item1) 
                                                           && (t.Item2 < range.Item2));
            if (lowerItem == null)
            {
                lowerItem = existingItems.Where(t => t.Item2 < range.Item1)?.OrderBy(t => t.Item2).Last();
            }
            //look for a partial overlap, or the closest item above our range
            var upperItem = existingItems.FirstOrDefault(t => (t.Item1 <= range.Item2) 
                                                           && (t.Item2 >= range.Item2) 
                                                           && (t.Item1 > range.Item1));
            if (upperItem == null)
            {
                upperItem = existingItems.Where(t => t.Item1 > range.Item2)?.OrderBy(t => t.Item1).First();
            }
            return new Tuple<int, int>(lowerItem.Item2 + 1, upperItem.Item1 - 1);
    }
