    public static int RemoveDuplicatesFromSecondRange2(List<string> list1, List<string> list2)
    {
      var exCount = list2.Select(s => s).Except(list1).Count();
      return list2.Count - exCount;
    }
