    string name = nm.ToUpper();
    var matching = Categories.Where(x => x.CategoryName.Contains(name)).ToList();
    if (matching.Count == 0)
    {
       return null;
    }
    Random rnd = new Random();
    return matching[rnd.Next(matching.Count)];
}
