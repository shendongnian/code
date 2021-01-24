    TimeSheetMaster masterModel = new TimeSheetMaster();
    masterModel.FromDate = timeSheetModel.Proj1;
    masterModel.ToDate = timeSheetModel.Proj1.AddDays(7);
    masterModel.TotalHours = timeSheetModel.ProjTotal1;
    masterModel.UserId = User.Identity.GetUserId();
    masterModel.DateCreated = DateTime.Now;
    masterModel.TimeSheetStatus = 1;
    masterModel.Comment = timeSheetModel.ProjDesc1;
    var detailsModel = CreateTimeSheetDetails(masterModel, timeSheetModel);
    // either here, or inside CreateTimeSheetDetails...
    // if Master has a collection of Details: (1-to-Many)
    masterModel.Details.Add(details);
    // or if Master has a 1-to-1 relationship to details.
    // masterModel.Details = detailsModel;
    context.TimeSheetMaster.Add(masterModel);
    context.SaveChanges();
