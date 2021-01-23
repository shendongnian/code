    private List<A> items = new List<A>();
    public IEnumerable<A> EveryA
    {
      get { return items; }
    }
    public IEnumerable<A> FilteredA
    {
      get { return items.Where(item => item.IsInFilter); }
    }
    public void AddItem(A item)
    {
      items.Add(item);
    }
