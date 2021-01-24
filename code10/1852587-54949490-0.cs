    public class ListFilterer
    {
        private readonly List<string>[] _searchSpace;
        public ListFilterer(List<string>[] searchSpace)
            => this._searchSpace = searchSpace ?? new List<string>[0];
        public IEnumerable<List<string>> GetListsHaving(params Tuple<int, string>[] query)
            => (from l in _searchSpace
                where AllConditionsMatch(l, query)
                select l);
        private static bool AllConditionsMatch(IReadOnlyList<string> lst, IEnumerable<Tuple<int, string>> conditions)
        {
            foreach (var cond in conditions)
            {
                if (cond.Item1 < 0 || cond.Item1 > lst.Count - 1)
                    return false;
                if (lst[cond.Item1] != cond.Item2)
                    return false;
            }
            return true;
        }
    }
