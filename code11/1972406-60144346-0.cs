    var result = documentClasses.GroupBy(c => new { c.Document, c.Revision }).Select(c => new
            {
                Document = c.Key.Document,
                Revision = c.Key.Revision,
                Version = c.Max()
            }).ToList();
