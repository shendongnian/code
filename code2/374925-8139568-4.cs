    .Select(r => new VisitDetails
        {                      
            Id = r.STEWARDSHIP_ID,                      
            Name = r.SITE.SITE_NAME,
            VisitDate = r.VISIT_DATE,
            VisitType = r.VISIT_TYPE_VAL.VISIT_TYPE_DESC                  
        });   
