    new SiteVisitDetails() // Note the parantheses
    {
        Id = r.STEWARDSHIP_ID,
        Name = r.SITE.SITE_NAME,
        VisitType = r.VISIT_TYPE_VAL.VISIT_TYPE_DESC,
        VisitDate = r.VISIT_DATE
    }
