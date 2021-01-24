    public static IEnumerable<string> EveryNthWord(
        this string sentence,
        int n,
        int offset = 0) =>
      sentence.Split(" ").TakeEveryNth(n, offset);
