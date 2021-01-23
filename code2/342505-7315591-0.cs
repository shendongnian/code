      var criteria = session.CreateCriteria<Comment>()
         .CreateAlias("Section.Page", "SectionPage")
         .Add(Restrictions.Eq("SectionPage.Id", pageId))
         .Add(Restrictions.Eq("SectionPage.Type", pageType))
         .Add(Restrictions.Ge("Date", start))
         .Add(Restrictions.Lt("Date", end));
