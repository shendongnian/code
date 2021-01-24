    db.Requests.Include(r => r.RequestStage).Include(r => r.MasterSections)
      .Where(r => r.RequestStage.name == "RequestSubmitted")
      .Join(_dbContext.LocalCodes.Include(l => l.MasterSections), rqst => rqst.MasterSectionID, lc => lc.MasterSectionId,
       (rt, lc) => new SectionResponse
                      {
                            Section = lc.Name,
                            Description = lc.Description,
                            CreatedBy = "",
                            Type = rt.Name.ToString(),
                            Status = rt.rs.Name,
    						/* Age property can not be done from within Queryable as .Date is not available in EF. If you want this, convert the query to enumerable and then project.*/
                            // Age = (DateTime.Now.Date - re.CreatedAt.Date).TotalDays.ToString() + "Days"
                       }).ToList();
