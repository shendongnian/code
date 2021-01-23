    var cs = from c in citrusList
             group c by new { c.Color, c.Flavor, c.Texture, c.State } into gcs
             let gs = gcs.Where(gc => gc.IsSmall == false)
             let ts = gcs.Where(gc => gc.IsSmall == true)
             let Tangelos = gs
                .Zip(ts, (g, t) =>
                    new Tangelo(g.Color, g.Flavor, g.Texture, g.State,
                        "A tangelo", new Decimal(0.75)))
             select new
             {
                 gcs.Key,
                 Grapefruit = gs.Skip(Tangelos.Count()),
                 Tangerines = ts.Skip(Tangelos.Count()),
                 Tangelos,
             };
    var container = new PackingContainer();
    container.AddRange(from c in cs
                       from f in c.Grapefruit
                           .Concat(c.Tangerines)
                           .Concat(c.Tangelos.Cast<Citrus>())
                       select f);
