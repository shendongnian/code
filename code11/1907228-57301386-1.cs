    var queryable = _ctx.People.Where(w => caseNoteResults.Select(s => s.PAS_INT_NO).Contains(w.PAS_INT_NO));
    queryable = string.IsNullOrEmpty(hcn) ? queryable : queryable.Where(w => w.CSA_NO.Contains(hcn, StringComparison.InvariantCulture));
    
    queryable = string.IsNullOrEmpty(forename) ? queryable : queryable.Where(w => w.FORENAMES.Contains(forename, StringComparison.InvariantCultureIgnoreCase));
    
    queryable = string.IsNullOrEmpty(surname) ? queryable : queryable.Where(w => w.SURNAME.Contains(surname, StringComparison.InvariantCultureIgnoreCase));
    
    personResults.AddRange(queryable.ToList());
