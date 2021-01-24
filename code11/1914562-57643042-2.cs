    public static List<string> RemoveDuplicatesFromSecondRange4(List<string> list1, List<string> list2)
    {
      return list2.Select(s => s).Except(list1).ToList();
      /* OR
      var h = new HashSet<string>(list1);
      return list2.Select(s => s).Except(h).ToList();
      */
    }
