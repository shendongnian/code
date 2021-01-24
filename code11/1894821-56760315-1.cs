    using (var db = new GestionIntegralContext())
    {
    
        var query = db.ClientProperties.GroupJoin(
            db.Properties,
            a => a.PROPREF,
            b => b.PROPREF,
            (a, b) => new { ClientProperties = a, Properties = b })
            .SelectMany(x => x.ClientProperties.Where(y => y.Contract == "TXT" && string.IsNullOrEmpty(y.PROPREF.ToString())),
            (a, b) => new { ClientProperties = a, Properties = b }).ToList();
    
    }
