    private List<string> XMLDuplicatesToEliminate(XDocument doc, Guid ApplianceTypeID)
    {
        var entities = new DbContextFactory().MAEDBSEntities;
    
        var applianceModels = doc.Descendants("Model");
        var applianceTypeColumns =
        (
            from at in entities.tApplianceTypeColumns
            where
                at.ApplianceTypeID == ApplianceTypeID &&
                at.ApplianceColumnUnique == true
            select new { at.ApplianceColumnName }
        ).ToList();
    
        var uniqueColumns = Enumerable.Concat(
            "Action,ManufacturerCode".Split(','),
            applianceTypeColumns
                .Select(at => at.ApplianceColumnName)
        );
    
        List<string> DuplicatesToEliminate = new List<string>();
        var duplicates = applianceModels
            .GroupBy(
                model => uniqueColumns.Select(columnName => model.Element(columnName)?.Value).ToArray(),
                new LambdaComparer<string[]>((a, b) => a.SequenceEqual(b), x => x.Aggregate(13, (hash, y) => hash * 7 + y?.GetHashCode() ?? 0)))
            .Where(x => x.Count() > 1)
            .Select(g => new { g.Key, Duplicates = g.Select(x => x.Element("CECID")?.Value) })
            .ToList();
    
        foreach (var duperow in duplicates)
        {
            string firstdupe = duperow.Duplicates.First();
            IEnumerable<string> allbutone = duperow.Duplicates.Where(x => x != firstdupe);
            foreach (string dupeitem in allbutone)
            {
                DuplicatesToEliminate.Add(dupeitem);
            }
        }
    
        return DuplicatesToEliminate;
    }
