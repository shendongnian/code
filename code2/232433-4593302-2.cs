    public static void KeepBiggestSubList<T>(List<List<T>> mainList)
    {
        if (mainList == null)
            throw new ArgumentNullException("mainList");
        if (mainList.Count == 0)
            return;
        List<T> maxList = mainList[0];
        foreach (List<T> list in mainList)
        {
            if (list.Count > maxList.Count)
                maxList = list;
        }
        mainList.Clear();
        mainList.Add(maxList);
    }
