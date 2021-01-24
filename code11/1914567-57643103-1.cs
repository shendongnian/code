    public static int RemoveDuplicatesFromSecondRange(List<string> list1, List<string> list2)
    {
      var inList2Only = list2.Except(list1).ToList();
      list2.Clear();
      list2.AddRange(inList2Only);
      return list1.Count - list2.Count;
    }
