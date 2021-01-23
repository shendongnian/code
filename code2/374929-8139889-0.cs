        public IEnumerable<SiteVisit> GetAllSiteVisits()
    {
        var visits =
            _db.STEWARDSHIP
               .OrderByDescending(r => r.VISIT_DATE)
               .Select(r => new SiteVisit
                   {
                       Id = r.STEWARDSHIP_ID,
                       Name = r.SITE.SITE_NAME,
                       VisitDate = r.VISIT_DATE,
                       VisitType = r.VISIT_TYPE_VAL.VISIT_TYPE_DESC
                   });
        return visits;
    }
