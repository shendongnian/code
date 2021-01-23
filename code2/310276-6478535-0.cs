    IList<int> list = new List<int> { 1, 2, 3, 4, 5, 1, 3, 5 };
    
    var valuesToRemove = list.Where(i => i == 1).ToArray();
    
    foreach (var item in valuesToRemove)
    {
        list.Remove(item);
    }
