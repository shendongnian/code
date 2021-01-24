    public ActionResult DisplayAllTimeSheetDetails(int masterid)
                {
                var masterModel = context.TimeSheetMaster.Where(w => 
                                  w.TimeSheetMasterId.Equals(masterid)).FirstOrDefault();
    
                var detailM = context.TimeSheetDetails.Where(t =>
                              t.TimeSheetMasterId.Equals(masterModel.TimeSheetMasterId)).FirstOrDefault();//.ToList();
    
                var project = context.Projects.Where(p => p.ProjectId==detailM.ProjectId).FirstOrDefault();
    
    
                var details = (from master in context.TimeSheetMaster
                               join detail in context.TimeSheetDetails
                               on master.TimeSheetMasterId equals detail.TimeSheetMasterId
                               select new TimeSheetDetailsModel()
                               {
                                   Sunday = detail.Sunday,
                                   Monday = detail.Monday,
                                   Tuesday = detail.Tuesday,
                                   Wednesday = detail.Wednesday,
                                   Thursday = detail.Thursday,
                                   Friday = detail.Friday,
                                   Saturday = detail.Saturday,
                                   Hours = detail.Hours,
                                   Comment = master.Comment,
                                   ProjectName = project.ProjectName
                               }).FirstOrDefault();
    
                return View(details);
            }
