    List<int> listStringVals = (new int[] { 7, 13, 8, 12, 10, 11, 14 }).ToList();
    List<int> SortedList = listStringVals.OrderBy(c => c).ToList();
    List<int> Gaps = Enumerable.Range(SortedList.First(), 
                                      SortedList.Last() - SortedList.First() + 1)
                               .Except(SortedList).ToList();
