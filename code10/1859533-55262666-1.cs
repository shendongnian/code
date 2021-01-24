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
            (p, v) => // for every product "p" we have a list of variants "v"
                v.Any() ? // do we have vriants for our product?
                    v.Select(s =>  new // for every variant we build our new product
                    {
                        Code = p.Code,
                        FirstVariant = s.Codvar,
                    })
                    : // if we got no variants, we build a "no variant"-product
                    new[] { new {
                        Code = p.Code,
                        FirstVariant = "No Variant"
                    } } // here we got a list of product-variants per product ("list of lists")
                ).SelectMany(s => s); // We want one list of all product variants
    foreach (var item in result)
    {
        Console.WriteLine("Code: {0}, FirstVar: {1}", item.Code, item.FirstVariant);
    }
