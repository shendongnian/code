    public static List<int> GetRandom()
    {
        var arr = Combinatorics.GeneratePermutation(25);
        return new List<int>(arr);
    }
