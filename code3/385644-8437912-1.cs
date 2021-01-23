    var subForms = repo.GetSubForms.Select(sf = new {
            SubForm = sf,
            Classes = sf.Classes.Where(c => c.TermId == termId)
        }).ToList()
        .Select(t => t.SubForm)
        .ToList();
