    var ones = JsonConvert
        .DeserializeObject<List<One>>(json1)
        .Select(x => (x.IdInOne, x.NameInOne));
    var lookups = JsonConvert
        .DeserializeObject<List<Two>>(json2)
        .Select(x => (x.IdInTwo, x.NameInTwo))
        .ToHashSet();
    foreach (var (IdInOne, NameInOne) in ones)
    {
        if (lookups.Contains((IdInOne, NameInOne)))
        {
            Console.WriteLine($"Match found with {IdInOne} and {NameInOne}");
        } else
        {
            Console.WriteLine($"No match found with {IdInOne} and {NameInOne}");
        }
    }
