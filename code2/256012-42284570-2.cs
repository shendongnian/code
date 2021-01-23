    var list = new List<string> { "a", "b", "c", "d", "e" };
    GetAllCombinations(list).OrderBy(_ => _).ToList().ForEach(Console.WriteLine);
    static IEnumerable<string> GetAllCombinations(IEnumerable<string> list)
    {
        return list.SelectMany(mainItem => list.Where(otherItem => !otherItem.Equals(mainItem))
                                  .Select(otherItem => mainItem + otherItem));
    }
