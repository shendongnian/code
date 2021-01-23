    // you could externalize and manage this list somewhere else 
    var sizes = new[] { "Large", "Medium", "Small" }; 
    if (string.IsNullOrEmpty(filename) || !sizes.Contains(size))
    {
        ...
    }
