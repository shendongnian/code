    var list = new List<string> { "abc", "def" };
    var list2 = new List<Tuple<string, string>>
    {
      new Tuple<string,string>("abc", "123"),
      new Tuple<string,string>("def", "456")
    };
    var items = (from i in context.Items
            where list.Contains(i.Name)
            select i)
            .AsEnumerable()
            .Where(i => list2.Any(j => j.val1 == i.Name && j.val2 == i.Type);
