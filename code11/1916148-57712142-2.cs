    var query = source.Join(..) ...;
    if (applicationId.HasValue) {
        query = query.Where(x => x.Id == applicationId.Value);
    }
    if (!String.IsNullOrEmpty(userName)) {
        query = query.Where(x => x.UserName == userName);
    }
    if (!String.IsNullOrEmpty(status)) {
        query = query.Where(x => x.StatusName == status);
    }
    query = query.Select(x => ...);
