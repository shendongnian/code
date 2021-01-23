    void DeletePlanTest()
    {
        PlanRepository repo = new PlanDbRepository("connection string");
        repo.CreateNewPlan(); // create plan and populate with tasks
        AssertIsTrue(repo.Plan.OpenTasks.Count == 2); // check tasks are in open state
        repo.DeletePlan();
        AssertIsTrue(repo.Plan.OpenTasks.Count == 0);
    }
