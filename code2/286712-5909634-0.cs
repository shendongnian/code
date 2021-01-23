           var results = from x in Colors.WithSurroundingNeighbours()
                         where !x.ItemShouldBeRemoved()
                         select x[2]; 
    public static  class Extensions
    {
        public static IEnumerable<List<T>> WithSurroundingNeighbours<T>(this IEnumerable<T> input) where T : class
        {
            var q = new List<T>();
            var twoNulls = new T[] {null, null};
            foreach (var item in twoNulls.Concat(input).Concat(twoNulls))
            {
                q.Add(item);
                if (q.Count < 5) continue;
                yield return q;
                q.RemoveAt(0);
            }
        }
        public static bool ItemShouldBeRemoved(this List<ColorResult> items) 
        {
            if (items.Count != 5) throw new ArgumentException("expected list with exactly 5 items");
            // TODO: return true when Item3 of the tuple should be removed
            // for the first item in the list, Item1 and Item2 are null
            // for the last item in the list, Item4 and Item5 are null
            return false;
        } 
    }
 
