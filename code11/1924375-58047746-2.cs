    private List<string> CreateListFrom(List<string> list)
    {
        return list.Where(type => !string.IsNullOrEmpty(type))
            .Select(type => type.Replace(".", "").Replace("*", ""))
            .Select(type => $".{type}")
            .ToList();
    }
