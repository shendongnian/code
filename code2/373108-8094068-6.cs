    private static IEnumerable<CollectionCategoryTitle> DistinctNewOrder(IEnumerable<CollectionCategoryTitle> src)
    {
      HashSet<string> seen = new HashSet<string>();
      //for one last time, change for different string comparisons, such as
      //new HashSet<string>(StringComparer.CurrentCultureIgnoreCase)
      foreach(var item in src)
        if(seen.Add(item.NewOrder))
          yield return item;
    }
    /*...*/
    var distinctTitles = reorderTitles.DistinctNewOrder().ToList();
