    public static IEnumerable<int> FindMissing(this List<int> list)
    {
        if (list.Count < 3) return Enumerable.Empty<int>(); // we do not need do check first           
        var listClone = new List<int>(list); //do not modify the original list
        listClone.Sort();
        for (int n = listClone[i] ; n < listClone[listClone.Count - 1] ; n++)
            if (!listClone.Contains(n))
                yield return n;
    }
