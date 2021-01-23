    var input = "abcdefghijklmnop";
    var result = new List<string>();
    int countForFirstGroup = input.Length % 3;
    if (countForFirstGroup > 0)
        result.Add(input.Substring(0, countForFirstGroup));
    for (int i = countForFirstGroup; i < input.Length; i+=3)
    {
        result.Add(input.Substring(i,3));
    }
