    public static List<int> Even(this List<int> numbers, Predicate<int> predicate = null)
    {
        predicate = predicate ?? new Predicate<int>(alwaysTrue);
        return numbers.Where(num=> num % 2 == 0 && predicate(num)).ToList();
    }
