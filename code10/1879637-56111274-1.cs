        static WorkItemClassificationNode CreateIteration(string TeamProjectName, string IterationName, DateTime? StartDate = null, DateTime? FinishDate = null, string ParentIterationPath = null)
        {
            WorkItemClassificationNode newIteration = new WorkItemClassificationNode();
            newIteration.Name = IterationName;
            if (StartDate != null && FinishDate != null)
            {
                newIteration.Attributes = new Dictionary<string, object>();
                newIteration.Attributes.Add("startDate", StartDate);
                newIteration.Attributes.Add("finishDate", FinishDate);
            }
            return WitClient.CreateOrUpdateClassificationNodeAsync(newIteration, TeamProjectName, TreeStructureGroup.Iterations, ParentIterationPath).Result;
        }
    var newNode = CreateIteration(TeamProjectName, @"R2");
    newNode = CreateIteration(TeamProjectName, @"R2.1", ParentIterationPath: @"R2");
    newNode = CreateIteration(TeamProjectName, @"Ver1", new DateTime(2019, 1, 1), new DateTime(2019, 1, 7), @"R2\R2.1");
