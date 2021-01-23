    var random = new Random();
    var result = new List<string>();
    var count = random.Next(10, 20); // How many results do you want, really!?
    for (int i = 0; i < count; ++i) {
        var query = from item in someLists
                    order by random.Next()
                    select item.Name;
        var items = query.ToList().Take(2);   // I assume you want two "names" in each item
        result.Add(string.Join("-", items));
    }
