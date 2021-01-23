    List<int> list = /* initialize */;
    IEnumerable<int> asEnumerable = list;
    // these call List<int>.Reverse(), which changes the list
    list.Reverse();
    ((List<int>)asEnumerable).Reverse();
    // these call Enumerable.Reverse<int>(), which does not change the list, but returns a new IEnumerable<int>
    asEnumerable.Reverse();
    ((IEnumerable<int>)list).Reverse();
    ((IList<int>)list).Reverse();
