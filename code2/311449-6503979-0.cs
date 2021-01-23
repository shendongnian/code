    private static readonly Predicate<int> AlwaysTrue = ignored => true;
    public static List<int> Even(this List<int> numbers,
                                 Predicate<int> predicate = null)
    {
        predicate = predicate ?? AlwaysTrue;
        return numbers.Where(num=> num % 2 == 0 && predicate(num));
    }
