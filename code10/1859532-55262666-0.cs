    List<Articolo> products = new List<Articolo>()
    {
        new Articolo() { Code = "1", price = 1 },
        new Articolo() { Code = "2", price = 1 },
        new Articolo() { Code = "3", price = 1 },
        new Articolo() { Code = "4", price = 1 },
        new Articolo() { Code = "5", price = 1 },
    };
    List<Variante> variants = new List<Variante>()
    {
        new Variante() { Code = "1", attivo = 0, Codvar = "v1" },
        new Variante() { Code = "3", attivo = 0, Codvar = "v1" },
        new Variante() { Code = "4", attivo = 0, Codvar = "v1" },
        new Variante() { Code = "4", attivo = 0, Codvar = "v2" },
        new Variante() { Code = "5", attivo = 1, Codvar = "v2" },
    };
    var result = products // Our "Left"-List 
        .GroupJoin( // Join to a "one"-to-"null or many"-List
            variants.Where(v => v.attivo == 0), // Our "right"-List
            p => p.Code, // select key in left list
            v => v.Code, // select key in right list
            (p, v) => new // select the result as new anonymous type.
            {
                Code = p.Code,
                FirstVariant = v.Any() ? v.First().Codvar : "No Variant", // Here we got a List of matching variants. If there are variants (Any==True) we select the first one.
                AllVariants = v, // we could also choose a list of variants
                AllVariantNames = String.Join(", ", v.Select(s => s.Codvar)) // or build some text with our variants
            } ).ToList();
    foreach (var item in result)
    {
        Console.WriteLine("Code: {0}, FirstVar: {1}, AllVars: {2}, Var-Count: {3}", item.Code, item.FirstVariant, item.AllVariantNames, item.AllVariants.Count());
    }
