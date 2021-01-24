    var query = factories.Select(f => new Shared.Models.Factory
        {
            Id = f.Id, 
            Name = f.Name,
            Serie = f.Serie,
            Hotline1 = f.FactoryHotLines
                .OrderBy(h => h.Id)
                .Select(h => new Shared.Models.FactoryHotline 
                {
                    Id = h.Id,
                    Caption = h.Caption,
                    Hotline = h.Hotline,
                    FactoryId = h.FactoryId
                }).FirstOrDefault(),
            Hotline2 = x.FactoryHotLines
                .OrderByDescending(h => h.Id)
                .Select(h => new Shared.Models.FactoryHotline 
                {
                    Id = h.Id,
                    Caption = h.Caption,
                    Hotline = h.Hotline,
                    FactoryId = h.FactoryId
                }).FirstOrDefault(),
         }).OrderBy(f => f.Name)
         .ToList();
