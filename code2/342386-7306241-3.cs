    public static IEnumerable<int> FindMissing(List<int> list)
    {
        if (list.Count < 3) yield break;
        List<int> listClone = new List<int>(list); //do not modify the original list
        listClone.Sort();
        for (int n = listClone[i] ; n < listClone[listClone.Count - 1]; n++)
            if (!listClone.Contains(n))
                yield return n;
    }
