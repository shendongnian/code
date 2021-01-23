    var newResults = new List<T>();
    foreach (T item in results)
    {
        if (!someCondition)
        {
            newResults.Add(item);
        }
    }
    results = newResults.ToArray();
