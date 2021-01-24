    mockActivityReportBO.Setup(x => x.AddReport(It.Is<ActivityReport>(
            x => x.Title == It.IsAny<string>()
            && x.Limits == It.IsAny<string>()
            && x.Description == It.IsAny<string>()
            && x.DueDate == It.IsInRange(DateTime.Now.AddDays(12), DateTime.MaxValue, Range.Inclusive)
            && x.CountyNumber == It.IsInRange(1, 5, Range.Inclusive)
            && x.ActivityReportID == It.IsInRange(1, 12, Range.Inclusive)
        )
    ));
