    public static List<ListItem> CompareLists(List<ListItem> existingList, List<ListItem> newList)
    {
        List<ListItem> mergedList = new List<ListItem>();
        mergedList.AddRange(newList);
        mergedList.AddRange(existingList.Except(newList, new ListItemComparer()));
        return mergedList.OrderByDescending(x => x.Score).Take(10).ToList();
    }
    public class ListItemComparer : IEqualityComparer<ListItem>
    {
        public bool Equals(ListItem x, ListItem y)
        {
            return x.Name == y.Name;
        }
        public int GetHashCode(ListItem obj)
        {
            return obj.Name.GetHashCode();
        }
    }
