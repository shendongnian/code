    //...omitted for brevity
    .Select(g => {
        var mostRecent = g.OrderByDescending(_ => _.InitialTraining.DateTakenInitial).First();
        // get the corresponding grade with the anchor from the Grading System table
        var gradeid = mostRecent.GradingSystemId;
        var gradingSystem = mostRecent.GradingSystem;
        //get the most recent date from the Initial Training
        var mostRecentDate = mostRecent.InitialTraining.DateTakenInitial
        //..get the desired values and assign to view model
        var model = new MedicStatistic {
            //Already have access to CodePerformanceAnchor
            PerformanceAnchorName = mostRecent.CodePerformanceAnchor.PerformanceAnchor
            AnchorCount = g.Count(),
            MostRecentlyCompleted = mostRecentDate,
        };
        return model;
    });
