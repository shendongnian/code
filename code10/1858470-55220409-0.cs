    public class IndicesSearch
    {
        private readonly List<int> filmDurations;
        private readonly Dictionary<int, int> valuesAndIndices;
        public IndicesSearch(List<int> filmDurations)
        {
            this.filmDurations = filmDurations;
            // preprocessing O(n)
            valuesAndIndices = filmDurations
                .Select((v, i) => new {value = v, index = i})
                .ToDictionary(k => k.value, v => v.index);
        }
        public (int, int) FindIndices(
            int flightDuration,
            int diff = 30)
        {
            // search, also O(n)
            for (var i = 0; i < filmDurations.Count; ++i)
            {
                var filmDuration = filmDurations[i];
                var toFind = flightDuration - filmDuration  - diff;
                if (valuesAndIndices.TryGetValue(toFind, out var j))
                    return (i, j);
            }
            
            // no solution found
            return (-1, -1); // or throw exception
        }
    }
