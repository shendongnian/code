    public static class TopologicalSorter
    {
    public static List<string> LastCyclicOrder; //used to see what caused the cycle
    sealed class ItemTag
    {
      public enum SortTag
      {
        NotMarked,
        TempMarked,
        Marked
      }
      public string Item { get; set; }
      public SortTag Tag { get; set; }
      public ItemTag(string item)
      {
        Item = item;
        Tag = SortTag.NotMarked;
      }
    }
    public static IEnumerable<string> TSort(this IEnumerable<string> source, Func<string, IEnumerable<string>> dependencies)
    {
      TopologicalSorter.LastCyclicOrder = new List<string>();
      List<ItemTag> allNodes = new List<ItemTag>();
      HashSet<string> sorted = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
      foreach (string item in source)
      {
        if (!allNodes.Where(n => string.Equals(n.Item, item, StringComparison.OrdinalIgnoreCase)).Any())
        {
          allNodes.Add(new ItemTag(item)); //don't insert duplicates
        }
        foreach (string dep in dependencies(item))
        {
          if (allNodes.Where(n => string.Equals(n.Item, dep, StringComparison.OrdinalIgnoreCase)).Any()) continue; //don't insert duplicates
          allNodes.Add(new ItemTag(dep));
        }
      }
      foreach (ItemTag tag in allNodes)
      {
        Visit(tag, allNodes, dependencies, sorted);
      }
      return sorted;
    }
    static void Visit(ItemTag tag, List<ItemTag> allNodes, Func<string, IEnumerable<string>> dependencies, HashSet<string> sorted)
    {
      if (tag.Tag == ItemTag.SortTag.TempMarked)
      {
        throw new GraphIsCyclicException();
      }
      else if (tag.Tag == ItemTag.SortTag.NotMarked)
      {
        tag.Tag = ItemTag.SortTag.TempMarked;
        LastCyclicOrder.Add(tag.Item);
        foreach (ItemTag dep in dependencies(tag.Item).Select(s => allNodes.Where(t => string.Equals(s, t.Item, StringComparison.OrdinalIgnoreCase)).First())) //get item tag which falls with used string
          Visit(dep, allNodes, dependencies, sorted);
        LastCyclicOrder.Remove(tag.Item);
        tag.Tag = ItemTag.SortTag.Marked;
        sorted.Add(tag.Item);
      }
    }
    }
