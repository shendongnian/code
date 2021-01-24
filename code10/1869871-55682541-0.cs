    var list = new List<termData>();
    list.Add(new termData() { Sequence = 1438690, Terms = "weather" });
    list.Add(new termData() { Sequence = 1438690, Terms = "the elements" });
    list.Add(new termData() { Sequence = 9672410, Terms = "dogs" });
    list.Add(new termData() { Sequence = 9672410, Terms = "cats" });
    var result = list
        .GroupBy(t => t.Sequence, t => t.Terms)
        .Select(g => g.Key + ";" + String.Join(";", g));
    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
