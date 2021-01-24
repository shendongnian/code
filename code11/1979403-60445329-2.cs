public static class ListExtensions{
  public List<List<T>> SplitPartition<T>(this IEnumerable<T> collection, int size)
  {
    var chunks = new List<List<T>>(collection.Count/size + 1);
    var temp = new List<T>(size);
    foreach (var element in collection)
    {
        if (temp.Count == size)
        {
            chunks.Add(temp);
            temp = new List<T>(size);
        }
        temp.Add(element);
    }
    chunks.Add(temp);
    return chunks;
  }
}
    
