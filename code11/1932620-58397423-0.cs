    public bool CheckUniqueName<T>(IEnumerable<T> items, string newName, Func<T, string> nameSelector)
    {
        foreach (var item in items)
        {
            string name = nameSelector(item);
            if (name == newName)
            {
                return false;
            }
        }
        return true;
    }
