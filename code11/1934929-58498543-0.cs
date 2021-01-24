public static IEnumerable<IEnumerable<int>> GetTriplePermutations(tis IEnumerable<int> array)
{
    return array.SelectMany((a, i)).Skip(x + 1).SelectMany((b, j)).Skip(y + 1)
}
You can calling this function by using `OddMethod(array).GetTriplePermutations();`
