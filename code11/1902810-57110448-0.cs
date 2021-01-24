    public class SearchItemIdComparer: IEqualityComparer<SearchItem>
    {
        public bool Equals(SearchItem x, SearchItem y)
        {
            if(x == null || y == null) return false;
            return x.IDItem == y.IDItem;
        }
        public int GetHashCode(SearchItem obj)
        {
            return obj?.IDItem ?? 0;
        }
    }
