    public void CodeIsUnique(string code, Action<bool, Exception> action)
    {
        bool isUnique = !_list.Any(o => string.Compare(o.Code, code) == 0);
        action(isUnique, null);
    }
