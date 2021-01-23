    public void SortListByPropertyName<T>(List<T> list, bool isAscending, string propertyName) where T : IComparable
    {
        var propInfo = typeof (T).GetProperty(propertyName);
        Comparison<T> asc = (t1, t2) => ((IComparable) propInfo.GetValue(t1, null)).CompareTo(propInfo.GetValue(t2, null));
        Comparison<T> desc = (t1, t2) => ((IComparable) propInfo.GetValue(t2, null)).CompareTo(propInfo.GetValue(t1, null));
        list.Sort(isAscending ? asc : desc);
    }
