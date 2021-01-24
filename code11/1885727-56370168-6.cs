    public static IEnumerable<string> EveryNthWord(
        this IEnumerable<string> sentences,
        int n,
        int offset = 0) =>
    sentences.SelectMany(sentence => sentence.EveryNthWord(n, offset));
