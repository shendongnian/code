    public static T RandomElement<T>(this IEnumerable<T> enumerable)
    {
        return enumerable.RandomElementUsing<T>(new Random());
    }
    public static T RandomElementUsing<T>(this IEnumerable<T> enumerable, Random rand)
    {
        int index = rand.Next(0, enumerable.Count());
        return enumerable.ElementAt(index);
    }
    // Usage:
    var ints = new int[] { 1, 2, 3 };
    int randomInt = ints.RandomElement();
    // If you have a preexisting `Random` instance, rand, use it:
    // this is important e.g. if you are in a loop, because otherwise you will create new
    // `Random` instances every time around, with nearly the same seed every time.
    int anotherRandomInt = ints.RandomElementUsing(rand);
