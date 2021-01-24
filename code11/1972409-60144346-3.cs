     var result = documents.GroupBy(c => new { c.Document, c.Revision })
            .Select(c => new DocumentClass
            {
                Document = c.Key.Document,
                Revision = c.Key.Revision,
                Version = c.Max(d=>d.Version)
            }).ToList();
