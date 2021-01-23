    public List<X> TypedList<X>(IList lst)
    {
        List<X> lstOut = new List<X>();
        for (int i = 0; i < lst.Count; i++)
        {
            if (lst[i] is X) lstOut.Add((X) lst[i]);
        }
        return lstOut;
    }
