    private static string[] VersionToArray(string version) {
      string[] result = version
        .Split('.')
        .Select(item => item.TrimStart('0'))
        .ToArray();
      // If we want to remove trailing zeros, i.e. 1.0.0.0.0.0 == 1.0.0.0 == 1.0:
      result = result
        .Reverse()
        .SkipWhile(item => item.All(c => c == '0'))
        .Reverse()
        .ToArray();
      return result;
    }
    private static int CompareVersions(string left, string right) {
      string[] leftArray = VersionToArray(left);
      string[] rightArray = VersionToArray(right);
      for (int i = 0; i < Math.Min(leftArray.Length, rightArray.Length); ++i) {
        int result = leftArray[i].Length.CompareTo(rightArray[i].Length);
        if (result == 0)
          result = string.Compare(leftArray[i], rightArray[i]);
        if (result != 0)
          return result;
      }
      return leftArray.Length.CompareTo(rightArray.Length);
    }
