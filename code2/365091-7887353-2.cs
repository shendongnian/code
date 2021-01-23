    private IEnumerable<long> GetDescHelper(List<Channel> list, long id, HashSet<long> already)
    {
      foreach(long child in GetChildren(list, id))
        if(already.Add(child))
        {
          yield return child;
          foreach(long desc in GetDescHelper(list, child, already))
            yield return desc;
        }
    }
    public IEnumerable<long> GetDescendants(List<Channel> list, long id)
    {
      return GetDescHelper(list, id, new HashSet<long>());
    }
