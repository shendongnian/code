    public void Execute()
    {
        Task.Factory.StartNew(Iterrate);
        Task.Factory.StartNew(Add);
    }
    private List<int> _list = Enumerable.Range(1, 10).ToList();
    private void Iterrate()
    {
        foreach (var item in _list)
        {
            Console.WriteLine(item);
        }
    }
    private void Add()
    {
        _list.Add(_list.Count);
    }
