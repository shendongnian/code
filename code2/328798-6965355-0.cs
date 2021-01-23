    public void Sort<T>(IList<T> list)
    {
        List<T> tmp = new List<T>(list);
        tmp.Sort();
        for (int i = 0; i < tmp.Count; i++)
        {
            list[i] = tmp[i];
        }
    }
