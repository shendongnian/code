    public static int RemoveDuplicatesFromSecondRange(List<string> list1, List<string> list2)
    {
      var beforeCount = list2.Count;
      var inList2Only = list2.Except(list1).ToList();
      list2.Clear();
      list2.AddRange(inList2Only);
      return beforeCount - inList2Only.Count;
    }
