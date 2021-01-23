    List<int> list = Enumerable.Range(1,100).ToList();
    While(list.Count>0)
    {
        list.RemoveAt(list.Count-1);
    }
