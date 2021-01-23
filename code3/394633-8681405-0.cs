     .OrderByDescending(r => r.VisitDate)
            .Where(r => SiteId == null || r.SiteAssoc.Id == iSiteId)
            .Where(r => r.MarkedForDeletion == false)
            .Select(r => new SearchResults()
                                           {
                                           ID = Ir.Id, 
                                           Name = r.SiteAssoc.Name, 
                                           VisitDate = r.VisitDate, 
                                           Description = r.VisitTypeValAssoc.Description
                                           });
