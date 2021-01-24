    //...omitted for brevity
    .Select(g => {
        var mostRecent = g.OrderByDescending(_ => _.InitialTraining.DateTakenInitial).First();
        //Get the Id
        var gradeid = mostRecent.GradingSystemId;
        //Or the object itself
        var gradingSystem = mostRecent.GradingSystem;
        //..get the desired values and assign to view model
        var item = new MedicStatistic {
            //Already have access to CodePerformanceAnchor
            PerformanceAnchorName = mostRecent.CodePerformanceAnchor.PerformanceAnchor
            AnchorCount = g.Count(),
            //for example, get the most recent date from the Initial Training
            MostRecentlyCompleted = mostRecent.InitialTraining.DateTakenInitial,
        };
        return item;
    });
