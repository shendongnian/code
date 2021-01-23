    var query = dc.agenda.AsQueryable();
    if (!string.IsNullOrEmpty(group))
        query = query.Where(a => a.no_group == group);
    if (group.Equals("990") || group.Equals(string.Empty))
        query = query.Where(a => (a.displaylocal.HasValue && a.displaylocal >= DateTime.Now) || 
            !a.displaylocal.HasValue);
    if (!string.IsNullOrEmpty(excludeManifestatie))
        query = query.Where(a => a.type_manifestation != excludeManifestatie);
    query = query.Where(a => (a.begindate.HasValue && a.begindate <= DateTime.Now) || 
                             !a.begindate.HasValue);
    query = query.Where(a => (a.enddate.HasValue && a.enddate >= DateTime.Now) || 
                             !a.enddate.HasValue);
