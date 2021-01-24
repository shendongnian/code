    public static int RemoveDuplicatesFromSecondRange3(List<string> list1, List<string> list2)
    {
      var h = new HashSet<string>(list1);
      var exCount = list2.Select(s => s).Except(h).Count();
      return list2.Count - exCount;
    }
