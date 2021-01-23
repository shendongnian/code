    var query = _db.STEWARDSHIP.OrderBy(r => r.SITE.SITE_NAME);
    if (SiteId != null)
    {
        query = query.Where(r => r.SITE_ID == SiteId);
    }
    query = query.Where(r => r.SITE.SITE_TYPE_VAL.SITE_TYPE_ID == SiteTypeId)
                 .Select(r => new
                  {
                      id = r.STEWARDSHIP_ID,
                      name = r.SITE.SITE_NAME,
                      visit_type = r.VISIT_TYPE_VAL.VISIT_TYPE_DESC,
                      visit_date = r.VISIT_DATE
                  });
    return query;
